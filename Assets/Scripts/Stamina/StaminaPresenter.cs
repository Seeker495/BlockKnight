using UnityEngine;
using UniRx;

public class StaminaPresenter : MonoBehaviour
{
    private StaminaModel staminaModel;
    private StaminaView staminaView;
    public ReadOnlyReactiveProperty<float> MaxStamina => staminaModel.MaxStamina;
    public ReadOnlyReactiveProperty<float> CurrentStamina => staminaModel.CurrentStamina;

    public void Initialize(float maxStamina)
    {
        staminaModel = new StaminaModel(maxStamina);
        CurrentStamina.Subscribe(value =>
        {
            float currentStaminaRatio = value / MaxStamina.Value;
            staminaView.UpdateStamina(currentStaminaRatio);
        }).AddTo(this);
    }

    public bool CanAttack(float attackStaminaCost)
    {
        return staminaModel.CurrentStamina.Value >= attackStaminaCost;
    }

    public void DecreaseStamina(float decreaseStamina)
    {
        staminaModel.DecreaseStamina(decreaseStamina);
    }

    public void IncreaseStamina(float increaseStamina)
    {
        staminaModel.IncreaseStamina(increaseStamina);
    }
}
