using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField]
    private Vector2 reflectDirection;
    [SerializeField]
    private ParticleSystem hitEffect;
    [SerializeField]
    private ParticleSystem chargeHitEffect;
    private PlayerInfo playerInfo;

    private float attackPower;
    private float attackAcceleration;
    private float hitStopSec;
    private bool isCharging;

    public void Initialize(PlayerInfo playerInfo)
    {
        this.playerInfo = playerInfo;
    }
    public void SetParameter(bool isCharging)
    {
        attackPower = isCharging ? playerInfo.ChargeAttackPower : playerInfo.AttackPower;
        attackAcceleration = isCharging ? playerInfo.ChargeAttackAcceleration : playerInfo.AttackAcceleration;
        hitStopSec = isCharging ? playerInfo.ChargeHitStopSec : playerInfo.HitStopSec;
        this.isCharging = isCharging;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //コア衝突時処理
        CoreSpeedController coreSpeedController;
        if (other.TryGetComponent(out coreSpeedController))
        {
            coreSpeedController.ChangeDirection(reflectDirection);
            coreSpeedController.IncreaseSpeed(attackAcceleration);

            if (coreSpeedController.IsFever)
            {
                coreSpeedController.GetComponent<CoreSplitter>().Split(3);
            }

            if (isCharging)
            {
                chargeHitEffect.transform.position = other.transform.position;
                chargeHitEffect.Play();
                coreSpeedController.GetComponent<CoreSplitter>().Split(1);
            }
            else
            {
                Debug.Log(hitEffect);
                hitEffect.transform.position = other.transform.position;
                hitEffect.Play();
            }
            //ヒットストップ処理
            HitStopManager.HitStop(hitStopSec);
        }

        //ブロック衝突時処理
        IDamageable damageable;
        if (other.TryGetComponent(out damageable))
        {
            damageable.TakeDamage(attackPower);
            //ヒットストップ処理
            HitStopManager.HitStop(hitStopSec);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)reflectDirection);
    }
}
