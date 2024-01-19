using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
using AsciiUtil;

[System.Serializable]
public class ButtonFeedbackAnimations
{
    [SerializeField, Header("ボタンにカーソルが乗った時のアニメーション")]
    public FeedbackActionData OnButtonEnter;
    [SerializeField, Header("ボタンからカーソルが離れた時のアニメーション")]
    public FeedbackActionData OnButtonExit;
    [SerializeField, Header("ボタンを押した時のアニメーション")]
    public FeedbackActionData OnButtonDown;
    [SerializeField, Header("ボタンを離した時のアニメーション")]
    public FeedbackActionData OnButtonUp;
    [SerializeField, Header("ボタンをクリックした時のアニメーション")]
    public FeedbackActionData OnButtonClick;
}

public enum ButtonFeedbackType
{
    ON_BUTTON_ENTER,
    ON_BUTTON_EXIT,
    ON_BUTTON_DOWN,
    ON_BUTTON_UP,
    ON_BUTTON_CLICK,
}
public class ButtonAction
{
    public UnityAction OnButtonEnter;
    public UnityAction OnButtonExit;
    public UnityAction OnButtonDown;
    public UnityAction OnButtonUp;
    public UnityAction OnButtonClick;
}
public class AsciiButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField, Header("フィードバックアニメーション")]
    private ButtonFeedbackAnimations uiFeedbackAnimations;
    public ButtonFeedbackAnimations UIFeedbackAnimations => uiFeedbackAnimations;
    private ButtonAction buttonActions = new ButtonAction();
    public ButtonAction ButtonActions => buttonActions;
    [SerializeField]
    protected bool isInteractable = true;
    public bool IsInteractable { set => isInteractable = value; }
    [SerializeField, Header("アニメーション後にイベントを発行するか")]
    private bool isActionAfterAnimation;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (!isInteractable) return;
        //アニメーションがない場合はそのままアクションを呼び出す
        if (uiFeedbackAnimations.OnButtonDown == null)
        {
            buttonActions.OnButtonDown?.Invoke();
            return;
        }

        PlayFeedbackAndAction(ButtonFeedbackType.ON_BUTTON_DOWN, isActionAfterAnimation);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
         if (!isInteractable) return;
        //アニメーションがない場合はそのままアクションを呼び出す
        if (uiFeedbackAnimations.OnButtonDown == null)
        {
            buttonActions.OnButtonDown?.Invoke();
            return;
        }

        PlayFeedbackAndAction(ButtonFeedbackType.ON_BUTTON_UP, isActionAfterAnimation);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (!isInteractable) return;
        //アニメーションがない場合はそのままアクションを呼び出す
        if (uiFeedbackAnimations.OnButtonDown == null)
        {
            buttonActions.OnButtonDown?.Invoke();
            return;
        }

        PlayFeedbackAndAction(ButtonFeedbackType.ON_BUTTON_CLICK, isActionAfterAnimation);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (!isInteractable) return;
        //アニメーションがない場合はそのままアクションを呼び出す
        if (uiFeedbackAnimations.OnButtonDown == null)
        {
            buttonActions.OnButtonDown?.Invoke();
            return;
        }

        PlayFeedbackAndAction(ButtonFeedbackType.ON_BUTTON_ENTER, isActionAfterAnimation);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
         if (!isInteractable) return;
        //アニメーションがない場合はそのままアクションを呼び出す
        if (uiFeedbackAnimations.OnButtonDown == null)
        {
            buttonActions.OnButtonDown?.Invoke();
            return;
        }

        PlayFeedbackAndAction(ButtonFeedbackType.ON_BUTTON_EXIT, isActionAfterAnimation);
    }

    private void PlayFeedbackAndAction(ButtonFeedbackType type, bool isActionAfterAnimation = false)
    {
        Tween tween = DOTween.Sequence();
        UnityAction action = null;
        switch (type)
        {
            case ButtonFeedbackType.ON_BUTTON_ENTER:
                tween = uiFeedbackAnimations.OnButtonEnter.CreateSequence(transform).sequence;
                action = buttonActions.OnButtonEnter;
                break;
            case ButtonFeedbackType.ON_BUTTON_EXIT:
                tween = uiFeedbackAnimations.OnButtonExit.CreateSequence(transform).sequence;
                action = buttonActions.OnButtonExit;
                break;
            case ButtonFeedbackType.ON_BUTTON_DOWN:
                tween = uiFeedbackAnimations.OnButtonDown.CreateSequence(transform).sequence;
                action = buttonActions.OnButtonDown;
                break;
            case ButtonFeedbackType.ON_BUTTON_UP:
                tween = uiFeedbackAnimations.OnButtonUp.CreateSequence(transform).sequence;
                action = buttonActions.OnButtonUp;
                break;
            case ButtonFeedbackType.ON_BUTTON_CLICK:
                tween = uiFeedbackAnimations.OnButtonClick.CreateSequence(transform).sequence;
                action = buttonActions.OnButtonClick;
                break;
        }

        if (isActionAfterAnimation)
        {
            tween.OnComplete(() => action?.Invoke());
            tween.Play();
            return;
        }
        tween.Play();
        action?.Invoke();
    }

}