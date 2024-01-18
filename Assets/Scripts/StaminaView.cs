using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UniRx;

public class StaminaView : MonoBehaviour
{
    [SerializeField, Header("HP変動時のアニメーション速度(秒)")]
    private float displayUpdateDurationSec = 0.5f;
    [SerializeField, Header("HP変動時のアニメーションのイージング")]
    private Ease displayUpdateEase = Ease.OutQuad;
    [SerializeField]
    private StaminaPresenter staminaPresenter;
    [SerializeField]
    private Image staminaFillImage;
    private float displayMaxStamina;
    private float displayStamina;
    private const float FILL_MAX = 1;
    private const float FILL_MIN = 0;

    /// <summary>
    /// TODO : 初期化処理をUnityのライフサイクルに依存しないようにしたほうが安定しそう
    /// </summary>
    private void Awake()
    {
        //初期化処理をPresenterに登録
        if (staminaPresenter == null)
        {
            Debug.LogError("StaminaPresenterがアタッチされていません");
            return;
        }
        staminaPresenter.onInitialize += () => Initialize();
    }

    private void Initialize()
    {
        //HP最大値変更時の処理
        staminaPresenter.MaxStamina.Subscribe(value => displayMaxStamina = value).AddTo(this);
        //HPの値が変わった時の処理
        staminaPresenter.CurrentStamina.Subscribe(value => UpdateStamina(value)).AddTo(this);
    }

    /// <summary>
    /// スタミナの値更新処理
    /// </summary>
    /// <param name="newStamina"></param>
    private void UpdateStamina(float newStamina)
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
        float fillAmount = value / displayMaxStamina;
        staminaFillImage.fillAmount = fillAmount;
    }
}
