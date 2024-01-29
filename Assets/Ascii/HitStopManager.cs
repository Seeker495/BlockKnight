using Cysharp.Threading.Tasks;
using UnityEngine;

public class HitStopManager
{
    public static async void HitStop(float stopSec)
    {
        Time.timeScale = 0;
        await UniTask.WaitForSeconds(stopSec, ignoreTimeScale: true);
        Time.timeScale = 1;
    }
}
