using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBlock : MonoBehaviour, IBlockable
{
    [SerializeField]
    private float coreSpeedUpValue;
    public void HitAction(CoreSpeedController coreSpeedController)
    {
        coreSpeedController.IncreaseSpeed(coreSpeedUpValue);
    }
}
