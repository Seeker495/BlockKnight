using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StaminaView : MonoBehaviour
{
    [SerializeField, Header("HP変動時のアニメーション速度(秒)")]
    private float displayUpdateDurationSec = 0.5f;
    [SerializeField, Header("HP変動時のアニメーションのイージング")]
    private Ease displayUpdateEase = Ease.OutQuad;
    [SerializeField]
    private Image staminaFillImage;
    private float displayStamina;

    /// <summary>
    /// スタミナの値更新処理
    /// </summary>
    /// <param name="newStamina"></param>
    public void UpdateStamina(float newStamina)
    {
        // DoTweenを使用してdisplayStaminaをnewStaminaまで滑らかに変更
        DOTween.To(() => displayStamina, x => displayStamina = x, newStamina, displayUpdateDurationSec)
        .SetEase(displayUpdateEase)
        .OnUpdate(() =>
        {
            StaminaViewUpdate(displayStamina);
        });
    }

    /// <summary>
    /// スタミナUIの見た目更新処理
    /// </summary>
    /// <param name="value"></param>
    private void StaminaViewUpdate(float value)
    {
        staminaFillImage.fillAmount = value;
    }
}
