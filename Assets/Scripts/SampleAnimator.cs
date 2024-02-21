using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.Animations;
#endif // UNITY_EDITOR
using UnityEngine;
using UnityEngine.InputSystem;



/* AnimationPreviewシーン用のスクリプト
 * playAnimationにanimationsに格納されているClipの名前を入れると再生してくれる
 * 
 */
#if UNITY_EDITOR
public class SampleAnimator : MonoBehaviour
{
    string playAnimation;
    private Animations animations;
    private List<string> animationNames;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out animations);
        animationNames = animations.GetAllAnimationName();
        GameController gameController = new GameController();
        gameController.AnimationPreview.Animation1.started += Animation1;
        gameController.AnimationPreview.Animation2.started += Animation2;
        gameController.AnimationPreview.Animation3.started += Animation3;
        gameController.AnimationPreview.Animation4.started += Animation4;
        gameController.AnimationPreview.Animation5.started += Animation5;
        gameController.AnimationPreview.Animation6.started += Animation6;
        gameController.AnimationPreview.Animation7.started += Animation7;
        gameController.AnimationPreview.Animation8.started += Animation8;
        gameController.AnimationPreview.Animation9.started += Animation9;
        gameController.AnimationPreview.Animation10.started += Animation10;
        gameController.Enable();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void Animation1(InputAction.CallbackContext context)
    {
        try
        {
            playAnimation = animationNames[0].Equals(null) ? null : animationNames[0];
            if (playAnimation == null) return;
            animations.Play(playAnimation);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NoAnimation");
            return;
        }
    }

    void Animation2(InputAction.CallbackContext context)
    {
        try
        {
            playAnimation = animationNames[1].Equals(null) ? null : animationNames[1];
            if (playAnimation == null) return;
            animations.Play(playAnimation);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NoAnimation");
            return;
        }
    }

    void Animation3(InputAction.CallbackContext context)
    {
        try
        {
            playAnimation = animationNames[2].Equals(null) ? null : animationNames[2];
            animations.Play(playAnimation);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NoAnimation");
            return;
        }
    }

    void Animation4(InputAction.CallbackContext context)
    {
        try
        {
            playAnimation = animationNames[3].Equals(null) ? null : animationNames[3];
            animations.Play(playAnimation);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NoAnimation");
            return;
        }


    }

    void Animation5(InputAction.CallbackContext context)
    {
        try
        {
            playAnimation = animationNames[4].Equals(null) ? null : animationNames[4];
            animations.Play(playAnimation);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NoAnimation");
            return;
        }
    }

    void Animation6(InputAction.CallbackContext context)
    {
        try
        {
            playAnimation = animationNames[5].Equals(null) ? null : animationNames[5];
            animations.Play(playAnimation);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NoAnimation");
            return;
        }
    }

    void Animation7(InputAction.CallbackContext context)
    {
        try
        {
            playAnimation = animationNames[6].Equals(null) ? null : animationNames[6];
            animations.Play(playAnimation);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NoAnimation");
            return;
        }
    }

    void Animation8(InputAction.CallbackContext context)
    {
        try
        {
            playAnimation = animationNames[7].Equals(null) ? null : animationNames[7];
            animations.Play(playAnimation);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NoAnimation");
            return;
        }
    }

    void Animation9(InputAction.CallbackContext context)
    {
        try
        {
            playAnimation = animationNames[8].Equals(null) ? null : animationNames[8];
            if (playAnimation == null) return;
            animations.Play(playAnimation);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NoAnimation");
            return;
        }
    }

    void Animation10(InputAction.CallbackContext context)
    {
        try
        {
            playAnimation = animationNames[9].Equals(null) ? null : animationNames[9];
            if (playAnimation == null) return;
            animations.Play(playAnimation);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log("NoAnimation");
            return;
        }
    }
}
#endif // UNITY_EDITOR
