using UnityEngine;
using UniRx;
using UnityEngine.Events;


public class StaminaPresenter : MonoBehaviour
{
    public UnityAction onInitialize { set; get; }
    private StaminaModel staminaModel;
    public ReadOnlyReactiveProperty<float> MaxStamina => staminaModel.MaxStamina;
    public ReadOnlyReactiveProperty<float> CurrentStamina => staminaModel.CurrentStamina;

    public bool CanAttack(float attackStaminaCost)
    {
        return staminaModel.CurrentStamina.Value >= attackStaminaCost;
    }
    public void Initialize(float maxStamina)
    {
        staminaModel = new StaminaModel(maxStamina);
        onInitialize?.Invoke();
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
