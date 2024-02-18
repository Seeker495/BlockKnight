using Cysharp.Threading.Tasks;
using UnityEngine;

public class HitStopManager
{
    [SerializeField]
    private static float onHitTimeScale = 0.1f;
    public static async void HitStop(float stopSec)
    {
        Time.timeScale = onHitTimeScale;
        await UniTask.WaitForSeconds(stopSec, ignoreTimeScale: true);
        Time.timeScale = 1;
    }
}
