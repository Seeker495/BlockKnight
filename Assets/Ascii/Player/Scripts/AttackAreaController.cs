using UnityEngine;

public class AttackAreaController : MonoBehaviour
{
    [SerializeField]
    private AttackArea[] attackAreas;
    private PlayerInfo playerInfo;

    public void Initialize(PlayerInfo playerInfo)
    {
        this.playerInfo = playerInfo;
        foreach (var attackArea in attackAreas)
        {
            attackArea.Initialize(playerInfo);
        }
    }

    public void Active(bool isCharging)
    {
        foreach (var attackArea in attackAreas)
        {
            attackArea.gameObject.SetActive(true);
            attackArea.SetParameter(isCharging);
        }
    }

    public void Disable()
    {
        foreach (var attackArea in attackAreas)
        {
            attackArea.gameObject.SetActive(false);
        }
    }
}
