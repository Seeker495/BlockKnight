using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSplitBlock : Block
{
    public override void HitAction(CoreSpeedController coreSpeedController)
    {
        base.HitAction(coreSpeedController);
        coreSpeedController.GetComponent<CoreSplitter>().Split();
    }
}
