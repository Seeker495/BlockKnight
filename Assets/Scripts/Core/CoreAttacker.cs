using UnityEngine;

public class CoreAttacker : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private void OnCollisionEnter2D(Collision2D other)
    {
        IDamageable damageable = null;
        if (!other.gameObject.TryGetComponent(out damageable)) return;
        damageable.TakeDamage(damage);
    }
}
