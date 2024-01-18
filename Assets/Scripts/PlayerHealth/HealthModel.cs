using UniRx;
using UnityEngine;

public class HealthModel
{
    private ReactiveProperty<float> maxHealth;
    public ReadOnlyReactiveProperty<float> MaxHealth => maxHealth.ToReadOnlyReactiveProperty();
    ReactiveProperty<float> currentHealth;
    public ReadOnlyReactiveProperty<float> CurrentHealth => currentHealth.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<bool> IsDead => currentHealth.Select(x => x <= MIN_HEALTH).ToReadOnlyReactiveProperty();
    private const float MIN_HEALTH = 0;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="maxHealth"></param>
    public HealthModel(float maxHealth)
    {
        Initialize(maxHealth);
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="maxHealth"></param>
    public void Initialize(float maxHealth)
    {
        this.maxHealth = new ReactiveProperty<float>(maxHealth);
        this.currentHealth = new ReactiveProperty<float>(maxHealth);
    }

    /// <summary>
    /// 被ダメージ処理
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(float damage)
    {
        //HPが0未満にならないようにダメージを受ける
        currentHealth.Value = Mathf.Clamp(currentHealth.Value - damage, MIN_HEALTH, maxHealth.Value);
    }

    /// <summary>
    /// 回復処理
    /// </summary>
    /// <param name="heal"></param>
    public void Heal(float heal)
    {
        //HPが最大値を超えないように回復する
        currentHealth.Value = Mathf.Clamp(currentHealth.Value + heal, MIN_HEALTH, maxHealth.Value);
    }
}
