using UnityEngine;
using UniRx;
using UnityEngine.Events;

public class HealthPresenter : MonoBehaviour, IDamageable
{
    private HealthModel healthModel;
    public ReadOnlyReactiveProperty<float> CurrentHealth => healthModel.CurrentHealth;
    public ReadOnlyReactiveProperty<float> MaxHealth => healthModel.MaxHealth;
    public ReadOnlyReactiveProperty<bool> IsDead => healthModel.IsDead;
    private UnityAction onDead;

    public void Initialize(float maxHealth)
    {
        healthModel = new HealthModel(maxHealth);
        //死亡時処理
        IsDead.Where(x => x)
              .Subscribe(_ => onDead?.Invoke())
              .AddTo(this);
    }

    public void TakeDamage(float damage)
    {
        healthModel.Damage(damage);
    }

    public void Heal(float heal)
    {
        healthModel.Heal(heal);
    }

    public void OnDeath(UnityAction action)
    {
        onDead += action;
    }
}
