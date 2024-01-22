using System.Collections;
using System.Collections.Generic;
using AsciiUtil;
using DG.Tweening;
using UnityEngine;

public class OutOfScreenBlock : Block
{
    [SerializeField]
    private FeedbackActionData cameraShakeTweenAction;
    public override void HitAction(CoreSpeedController coreSpeedController)
    {
        base.HitAction(coreSpeedController);
        cameraShakeTweenAction.CreateSequence(transform).Play();
    }
}
