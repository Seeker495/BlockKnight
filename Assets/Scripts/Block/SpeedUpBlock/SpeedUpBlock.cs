using UnityEngine;

public class SpeedUpBlock : Block
{
    [SerializeField]
    private float coreSpeedUpValue;
    public override void HitAction(CoreSpeedController coreSpeedController)
    {
        base.HitAction(coreSpeedController);
        coreSpeedController.IncreaseSpeed(coreSpeedUpValue);
    }
}
