using AsciiUtil;
using UnityEngine;
using UniRx;
using AsciiUtil.UI;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameMainController : MonoBehaviour
{
    [SerializeField]
    private string gameBGMKey = "Stage_Blockgolem";
    [SerializeField]
    private CoreSpeedController core;
    [SerializeField]
    private GameEvent gameClearEvent;
    [SerializeField]
    private GameEvent gameOverEvent;
    [SerializeField]
    private AsciiPopupWindow gameClearPopupWindow;
    [SerializeField]
    private AsciiPopupWindow gameOverPopupWindow;
    [SerializeField]
    private AsciiButton clearHomeButton, gameOverHomeButton;
    [SerializeField]
    private AsciiButton retryButton;

    public float heartBeatInterval { get; set; } = 1.0f;

    private CancellationTokenSource heartBeatCTS = new CancellationTokenSource();
    void Start()
    {
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayBGM(gameBGMKey);

        gameOverEvent.EventSubject.Subscribe(_ =>
        {
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySE("Gameover");
            gameOverPopupWindow.OpenPopupWindow();
            Destroy(core);
            heartBeatCTS?.Cancel();
        });

        gameClearEvent.EventSubject.Subscribe(_ =>
        {
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySE("Gameclear");
            gameClearPopupWindow.OpenPopupWindow();
            Destroy(core);
            heartBeatCTS?.Cancel();
        });

        PlayHeartBeatSound().Forget();

        clearHomeButton.ButtonActions.OnButtonClick += () =>
        {
            SoundManager.Instance.PlaySE("Click_Button");
            SceneManager.LoadScene("Title");
        };

        gameOverHomeButton.ButtonActions.OnButtonClick += () =>
        {
            SoundManager.Instance.PlaySE("Click_Button");
            SceneManager.LoadScene("Title");
        };

        retryButton.ButtonActions.OnButtonClick += () =>
        {
            SoundManager.Instance.PlaySE("Click_Button");
            SceneManager.LoadScene("Tutorial");
        };
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
