using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StaminaModel
{
    private ReactiveProperty<float> maxStamina;
    public ReadOnlyReactiveProperty<float> MaxStamina => maxStamina.ToReadOnlyReactiveProperty();
    private ReactiveProperty<float> currentStamina;
    public ReadOnlyReactiveProperty<float> CurrentStamina => currentStamina.ToReadOnlyReactiveProperty();
    private const float MIN_STAMINA = 0;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="maxStamina"></param>
    public StaminaModel(float maxStamina)
    {
        Initialize(maxStamina);
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="maxStamina"></param>
    public void Initialize(float maxStamina)
    {
        this.maxStamina = new ReactiveProperty<float>(maxStamina);
        this.currentStamina = new ReactiveProperty<float>(maxStamina);
    }

    public void DecreaseStamina(float decreaseStamina)
    {
        currentStamina.Value = Mathf.Clamp(currentStamina.Value - decreaseStamina, MIN_STAMINA, maxStamina.Value);
    }

    public void IncreaseStamina(float increaseStamina)
    {
        currentStamina.Value = Mathf.Clamp(currentStamina.Value + increaseStamina, MIN_STAMINA, maxStamina.Value);
    }
}
