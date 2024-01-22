using AsciiUtil;
using UnityEngine;

public class CoreAttacker : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private ParticlePlayer particlePlayer;
    private void OnCollisionEnter2D(Collision2D other)
    {
        IDamageable damageable = null;
        if (!other.gameObject.TryGetComponent(out damageable)) return;
        particlePlayer.Play("HitBlock", other.transform.position);
        damageable.TakeDamage(damage);
    }
}
