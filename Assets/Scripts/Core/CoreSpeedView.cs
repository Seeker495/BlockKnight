using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CoreSpeedView : MonoBehaviour
{
    [SerializeField, Header("HP変動時のアニメーション速度(秒)")]
    private float displayUpdateDurationSec = 0.5f;
    [SerializeField, Header("HP変動時のアニメーションのイージング")]
    private Ease displayUpdateEase = Ease.OutQuad;
    [SerializeField]
    private Image coreSpeedFillImage;
    [SerializeField]
    private Image heartImage;
    [SerializeField]
    private SpriteAnimationPlayer spriteAnimationPlayer;
    [SerializeField]
    private TextMeshProUGUI coreSpeedText;

    private float displayCoreSpeed;
    private CoreInfo coreInfo;
    private Material heartImageMaterial;

    private void Start()
    {
        coreInfo = InfomationProvider.Instance.CoreInfo;
        heartImageMaterial = heartImage.material;
        spriteAnimationPlayer.Play();
    }

    public void UpdateCoreSpeed(float newCoreSpeed)
    {
        DOTween.To(() => displayCoreSpeed, x => displayCoreSpeed = x, newCoreSpeed, displayUpdateDurationSec)
        .SetEase(displayUpdateEase)
        .OnUpdate(() =>
        {
            CoreSpeedViewUpdate(displayCoreSpeed);
        });
    }
    private void CoreSpeedViewUpdate(float value)
    {
        coreSpeedFillImage.fillAmount = value / coreInfo.MaxSpeed;
        coreSpeedText.text = ConvertSpeedForDisplay(value).ToString("F0");
        float outlineDistortionAmount = Mathf.Clamp(coreSpeedFillImage.fillAmount, 0, 0.7f);
        heartImageMaterial.SetFloat("_OutlineDistortAmount", outlineDistortionAmount);
    }

    private float ConvertSpeedForDisplay(float actualSpeed)
    {
        float normalized = (actualSpeed - coreInfo.MinSpeed) / (coreInfo.MaxSpeed - coreInfo.MinSpeed);
        return normalized * (coreInfo.DisplayMaxSpeed - coreInfo.DisplayMinSpeed) + coreInfo.DisplayMinSpeed;
    }

}
