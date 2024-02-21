using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour, IBlockable, IDamageable
{
    [SerializeField]
    private float hp;
    [SerializeField, Header("破壊不可能なブロックかどうか")]
    private bool isIndestructible;
    private SpriteRenderer crackSpriteRenderer;
    [SerializeField]
    private Sprite[] crackSprites;
    private CoreInfo coreInfo;
    private UnityAction onDeath;

    private void Start()
    {
        coreInfo = InfomationProvider.Instance.CoreInfo;
        if (isIndestructible) return;
        crackSpriteRenderer = transform.Find("Crack").GetComponent<SpriteRenderer>();
    }

    public void Initialize(UnityAction onDeath)
    {
        this.onDeath = onDeath;
    }

    public virtual void HitAction(CoreSpeedController coreSpeedController)
    {
        // coreSpeedController.IncreaseSpeed(coreInfo.OnHitBlockSpeedUpValue);
    }

    public virtual void TakeDamage(float damage)
    {
        if (isIndestructible) return;
        hp -= damage;
        if (hp >= 3)
        {
            crackSpriteRenderer.sprite = crackSprites[0];
        }
        else if (hp >= 2)
        {
            crackSpriteRenderer.sprite = crackSprites[1];
        }
        else if (hp >= 1)
        {
            crackSpriteRenderer.sprite = crackSprites[2];
        }
        else
        {
            onDeath?.Invoke();
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
