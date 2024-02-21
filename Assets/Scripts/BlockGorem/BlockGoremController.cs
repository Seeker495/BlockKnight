using AsciiUtil;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BlockGoremController : MonoBehaviour
{
    [SerializeField] private GameEvent deathEvent;
    [SerializeField] private BlockGoremInfo info;
    private int maxHealth;
    private bool isDefeated;
    private FloatReactiveProperty health;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator swordAnimator;
    private CancellationTokenSource cts;



    // Start is called before the first frame update
    void Start()
    {
        cts = new CancellationTokenSource();
        TryGetComponent(out animator);
        swordAnimator = GameObject.FindWithTag("Sword").GetComponent<Animator>();
        isDefeated = false;


        //あすきー追記ここから
        var blocks = GetComponentsInChildren<Block>().ToList();
        blocks.ForEach(b => b.Initialize(() => HealthUpdate()));
        maxHealth = blocks.Count;
        //あすきー追記ここまで

        //maxHealth = GetComponentsInChildren<Block>().ToList().Count;
        health = new FloatReactiveProperty(maxHealth);
        Debug.Log(maxHealth);
        health.Subscribe(h =>
        {
            if (maxHealth * (1 - info.DestroyedBlockRatio) >= h)
            {
                deathEvent.Raise();
                isDefeated = true;
            }

            if (!isDefeated)
            {
                //個数を数える処理をブロックにイベントベースで実装したためコメントアウト
                //GetCurrentBlockCount(cts.Token).Forget();
                Attack(cts.Token).Forget();
            }

        }).AddTo(gameObject);

    }

    private void HealthUpdate()
    {
        health.Value = GetComponentsInChildren<Block>().Length;
    }

    private void OnDestroy()
    {
        animator = null;
        swordAnimator = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private async UniTaskVoid GetCurrentBlockCount(CancellationToken token)
    {

        while (!token.IsCancellationRequested && !destroyCancellationToken.IsCancellationRequested)
        {
            if (GetComponentsInChildren<Block>().Length == 0)
            {
                continue;
            }
            var currentHealth = GetComponentsInChildren<Block>().ToList().Count;
            health.Value = currentHealth;
            await UniTask.WaitForFixedUpdate(token);
        }
    }

    private async UniTaskVoid Attack(CancellationToken token)
    {


        while (!destroyCancellationToken.IsCancellationRequested)
        {
            await UniTask.WaitForSeconds(Random.Range(info.MinInterval, info.MaxInterval), false, PlayerLoopTiming.Update, token);
            if (animator != null)
            {
                animator?.SetInteger("attackPattern", Random.Range(1, 3));
                switch (animator?.GetInteger("attackPattern"))
                {
                    case 1:
                        swordAnimator?.SetInteger("attackPattern", Random.Range(0, 3));
                        await UniTask.WaitForSeconds(info.SwordAttackStiffness, false, PlayerLoopTiming.Update, token);
                        break;
                    case 2:
                        await UniTask.WaitForSeconds(info.RushAttackStiffness, false, PlayerLoopTiming.Update, token);
                        break;
                    default:
                        break;
                }
                animator?.SetInteger("attackPattern", 0);
                swordAnimator?.SetInteger("attackPattern", 3);
            }
        }

        await destroyCancellationToken.WaitUntilCanceled();
    }
}
