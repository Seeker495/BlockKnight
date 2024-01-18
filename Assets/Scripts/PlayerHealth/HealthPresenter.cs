using UnityEngine;
using UniRx;
using UnityEngine.Events;
using UniRx.Triggers;

public class HealthPresenter : MonoBehaviour, IDamageable
{
    private HealthModel healthModel;
    public ReadOnlyReactiveProperty<float> CurrentHealth => healthModel.CurrentHealth;
    public ReadOnlyReactiveProperty<float> MaxHealth => healthModel.MaxHealth;
    public ReadOnlyReactiveProperty<bool> IsDead => healthModel.IsDead;
    public UnityAction onDead { set; get; }
    public UnityAction onInitialize { set; get; }

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="maxHealth"></param>
    public void Initialize(float maxHealth)
    {
        healthModel = new HealthModel(maxHealth);
        onInitialize?.Invoke();
        //死亡時処理
        IsDead.Where(x => x)
              .Subscribe(_ => onDead?.Invoke())
              .AddTo(this);
    }

    /// <summary>
    /// 被ダメージ処理
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        healthModel.Damage(damage);
    }

    /// <summary>
    /// 回復処理
    /// </summary>
    /// <param name="heal"></param>
    public void Heal(float heal)
    {
        healthModel.Heal(heal);
    }
}
