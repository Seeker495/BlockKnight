using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour, IBlockable, IDamageable
{
    [SerializeField]
    private float hp;
    [SerializeField, Header("破壊不可能なブロックかどうか")]
    private bool isIndestructible;
    private CoreInfo coreInfo;

    private void Start()
    {
        coreInfo = InfomationProvider.Instance.CoreInfo;
    }

    public virtual void HitAction(CoreSpeedController coreSpeedController)
    {
        coreSpeedController.IncreaseSpeed(coreInfo.OnHitBlockSpeedUpValue);
    }

    public virtual void TakeDamage(float damage)
    {
        if (isIndestructible) return;
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

public enum BlockModuleType
{
    CoreSpeedUp,
    CoreSpeedDown,
    SplitCore,
}
