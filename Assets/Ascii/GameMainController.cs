using AsciiUtil;
using UnityEngine;
using UniRx;
using AsciiUtil.UI;
using System.Threading;
using Cysharp.Threading.Tasks;

public class GameMainController : MonoBehaviour
{
    [SerializeField]
    private string gameBGMKey = "Stage_Blockgolem";
    [SerializeField]
    private GameEvent gameClearEvent;
    [SerializeField]
    private GameEvent gameOverEvent;
    [SerializeField]
    private AsciiPopupWindow gameClearPopupWindow;
    [SerializeField]
    private AsciiPopupWindow gameOverPopupWindow;

    public float heartBeatInterval { get; set; } = 1.0f;

    private CancellationTokenSource heartBeatCTS = new CancellationTokenSource();
    void Start()
    {
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayBGM(gameBGMKey);

        gameOverEvent.EventSubject.Subscribe(_ =>
        {
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySE("GameOver");
            gameOverPopupWindow.OpenPopupWindow();
            heartBeatCTS?.Cancel();
        });

        gameClearEvent.EventSubject.Subscribe(_ =>
        {
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySE("GameClear");
            gameClearPopupWindow.OpenPopupWindow();
            heartBeatCTS?.Cancel();
        });

        PlayHeartBeatSound().Forget();
    }

    private async UniTaskVoid PlayHeartBeatSound()
    {
        while (heartBeatCTS.Token.IsCancellationRequested)
        {
            SoundManager.Instance.PlaySE("HeartBeat");
            await UniTask.WaitForSeconds(heartBeatInterval);
        }
    }
}
