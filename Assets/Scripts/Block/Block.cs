using UnityEngine;

public class Block : MonoBehaviour, IBlockable
{
    private CoreInfo coreInfo;
    private void Start()
    {
        coreInfo = InfomationProvider.Instance.CoreInfo;
    }
    public virtual void HitAction(CoreSpeedController coreSpeedController)
    {
        coreSpeedController.IncreaseSpeed(coreInfo.OnHitBlockSpeedUpValue);
    }
}
