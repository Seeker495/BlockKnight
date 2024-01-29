using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class CoreSpeedController : MonoBehaviour
{
    private FloatReactiveProperty currentSpeed;
    public ReadOnlyReactiveProperty<float> CurrentSpeed => currentSpeed.ToReadOnlyReactiveProperty();
    private CoreInfo coreInfo;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        coreInfo = InfomationProvider.Instance.CoreInfo;
        currentSpeed = new FloatReactiveProperty(0);

        // 現在のvelocityを維持したまま、速度を変更する
        currentSpeed.Subscribe(speed =>
        {
            rigidBody.velocity = rigidBody.velocity.normalized * speed;
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

    private float ClampSpeed(float speed)
    {
        return Mathf.Clamp(speed, coreInfo.MinSpeed, coreInfo.MaxSpeed);
    }
}
