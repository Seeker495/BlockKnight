using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using AsciiUtil;
using System.Threading;

public class CoreSpeedController : MonoBehaviour
{
    [SerializeField]
    private GameEvent playerDeathEvent;
    [SerializeField]
    private CoreSplitter coreSplitter;
    [SerializeField]
    private SpriteRendererAnimationPlayer spriteRendererAnimationPlayer;
    private FloatReactiveProperty currentSpeed;
    public ReadOnlyReactiveProperty<float> CurrentSpeed => currentSpeed.ToReadOnlyReactiveProperty();
    private CoreInfo coreInfo;
    private Rigidbody2D rigidBody;
    private bool isFever = false;
    public bool IsFever => isFever;
    private float maxSpeedEightyPercent;
    private CancellationTokenSource feverCTS;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        coreInfo = InfomationProvider.Instance.CoreInfo;
        currentSpeed = new FloatReactiveProperty(coreInfo.InitialSpeed);
        maxSpeedEightyPercent = coreInfo.MaxSpeed * 0.8f;

        // 現在のDirectionを維持したまま、速度を変更する
        currentSpeed.Subscribe(speed =>
        {
            if (isFever)
            {
                //フィーバー中は最高速度で固定
                rigidBody.velocity = rigidBody.velocity.normalized * coreInfo.MaxSpeed;
                currentSpeed.Value = coreInfo.MaxSpeed;
                return;
            }
            rigidBody.velocity = rigidBody.velocity.normalized * speed;

            if (speed >= maxSpeedEightyPercent)
            {
                StartFeverTimer().Forget();
            }
            else
            {
                feverCTS?.Cancel();
                feverCTS = null;
            }

            if (speed <= coreInfo.MinSpeed)
            {
                playerDeathEvent.Raise();
            }
        });

        // 速度を時間経過で減少させる
        DecreaseSpeedPerSecond().Forget();

        // デバッグ用 コア発射
        LaunchCore(new Vector2(1, 1), coreInfo.InitialSpeed);
    }

    /// <summary>
    /// コアを発射します
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="speed"></param>
    public void LaunchCore(Vector2 direction, float speed)
    {
        rigidBody.velocity = direction.normalized;
        currentSpeed.Value = speed;
    }

    /// <summary>
    /// 速度を上昇させます
    /// </summary>
    /// <param name="value"></param>
    public void IncreaseSpeed(float value)
    {
        currentSpeed.Value = ClampSpeed(currentSpeed.Value + value);
    }

    public void DecreaseSpeed(float value)
    {
        currentSpeed.Value = ClampSpeed(currentSpeed.Value - value);
    }

    public void ChangeDirection(Vector2 direction)
    {
        rigidBody.velocity = direction.normalized * currentSpeed.Value;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IBlockable blockable = null;
        if (!other.gameObject.TryGetComponent(out blockable)) return;
        SoundManager.Instance.PlaySE("Core_Reflection");
        if (isFever)
        {
            coreSplitter.Split(2);
        }
        if (blockable is OutOfScreenBlock)
        {
            var contactPoint = other.contacts[0].point;
            var animationDirection = contactPoint - (Vector2)transform.position;
            var animation = Instantiate(spriteRendererAnimationPlayer, transform.position, Quaternion.identity);
            if (animationDirection.y > 0.3)
            {
            }
            else if (animationDirection.x < 0)
            {
                animation.transform.Rotate(0, 0, 90);
            }
            else if (animationDirection.x > 0)
            {
                animation.transform.Rotate(0, 0, -90);
            }
            animation.Play();
        }
        blockable.HitAction(this);
    }

    private async UniTaskVoid DecreaseSpeedPerSecond()
    {
        while (true)
        {
            currentSpeed.Value = ClampSpeed(currentSpeed.Value - coreInfo.SpeedDecreaseValue);
            await UniTask.WaitForSeconds(coreInfo.SpeedDecreaseInterval);
        }
    }

    private async UniTaskVoid StartFeverTimer()
    {
        if (feverCTS != null) return;
        feverCTS = new CancellationTokenSource();
        await UniTask.WaitForSeconds(coreInfo.FeverNeedTime, cancellationToken: feverCTS.Token);
        isFever = true;
        StartFever().Forget();
    }

    private async UniTaskVoid StartFever()
    {
        await UniTask.WaitForSeconds(coreInfo.FeverTime);
        isFever = false;
    }

    private float ClampSpeed(float speed)
    {
        return Mathf.Clamp(speed, coreInfo.MinSpeed, coreInfo.MaxSpeed);
    }

    private void OnBecameInvisible()
    {
        playerDeathEvent.Raise();
    }
}
