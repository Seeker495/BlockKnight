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
    private SpriteAnimationPlayer spriteAnimationPlayer;
    [SerializeField]
    private TextMeshProUGUI coreSpeedText;

    private float displayCoreSpeed;
    private CoreInfo coreInfo;

    private void Start()
    {
        coreInfo = InfomationProvider.Instance.CoreInfo;
        spriteAnimationPlayer.Play();
    }

    public void UpdateCoreSpeed(float newCoreSpeed)
    {
        // DoTweenを使用してdisplayStaminaをnewStaminaまで滑らかに変更
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
        coreSpeedText.text = value.ToString("F0");
    }

}
