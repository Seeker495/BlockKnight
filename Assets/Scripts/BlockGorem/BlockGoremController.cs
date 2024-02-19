using AsciiUtil;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class BlockGoremController : MonoBehaviour
{
    [SerializeField] private GameEvent deathEvent;
    [SerializeField] private BlockGoremInfo info;
    private int maxHealth;
    private bool isDefeated;
    private FloatReactiveProperty health;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator swordAnimator;


    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out animator);
        isDefeated = false;
        maxHealth = GetComponentsInChildren<Block>().ToList().Count;
        health = new FloatReactiveProperty(maxHealth);
        Debug.Log(maxHealth);
        health.Subscribe(h =>
        {
            if (maxHealth * (1 - info.DestroyedBlockRatio) >= h)
            {
                deathEvent.Raise();
                isDefeated = true;
            }
        }).AddTo(this);

        GetCurrentBlockCount().Forget();
        Attack().Forget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async UniTaskVoid GetCurrentBlockCount()
    {
        while (isDefeated == false)
        {
            health.Value = GetComponentsInChildren<Block>().ToList().Count;
            await UniTask.WaitForFixedUpdate();
        }
    }

    private async UniTaskVoid Attack()
    {
        while (true)
        {
            
            await UniTask.WaitForSeconds(Random.Range(info.MinInterval, info.MaxInterval));
            animator.SetInteger("attackPattern", Random.Range(1, 3));
            switch (animator.GetInteger("attackPattern"))
            {
                case 1:
                    swordAnimator.SetInteger("SwordInt", Random.Range(0, 3));
                    await UniTask.WaitForSeconds(info.SwordAttackStiffness);
                    break;
                case 2:
                    await UniTask.WaitForSeconds(info.RushAttackStiffness);
                    break;
                default:
                    break;
            }
            animator.SetInteger("attackPattern", 0);
            swordAnimator.SetInteger("SwordInt", 3);
        }
    }
}
