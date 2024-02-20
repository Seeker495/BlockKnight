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
    private AsciiButton tweetButton;
    [SerializeField]
    private TweetInfo tweetInfo;
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

    private bool isGameOver = false;
    private bool isGameClear = false;

    public float heartBeatInterval { get; set; } = 1.0f;

    private CancellationTokenSource heartBeatCTS = new CancellationTokenSource();
    void Start()
    {
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayBGM(gameBGMKey);

        gameOverHomeButton.IsInteractable = false;
        retryButton.IsInteractable = false;

        gameOverEvent.EventSubject.Subscribe(async _ =>
        {
            if (isGameOver) return;
            isGameOver = true;
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySE("Gameover");
            await gameOverPopupWindow.OpenPopupWindow();
            Destroy(core);
            heartBeatCTS?.Cancel();
            gameOverHomeButton.IsInteractable = true;
            retryButton.IsInteractable = true;
            UnityEngine.Time.timeScale = 0;
        });

        gameClearEvent.EventSubject.Subscribe(async _ =>
        {
            if (isGameClear) return;
            isGameClear = true;
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySE("Gameclear");
            await gameClearPopupWindow.OpenPopupWindow();
            Destroy(core);
            heartBeatCTS?.Cancel();
            clearHomeButton.IsInteractable = true;
            tweetButton.IsInteractable = true;
            UnityEngine.Time.timeScale = 0;
        });

        PlayHeartBeatSound().Forget();

        clearHomeButton.ButtonActions.OnButtonClick += async () =>
        {
            SoundManager.Instance.PlaySE("Click_Button");
            SceneManager.LoadScene("Title");
            await UniTask.WaitForSeconds(0.3f, ignoreTimeScale: true);
            UnityEngine.Time.timeScale = 1;
        };

        gameOverHomeButton.ButtonActions.OnButtonClick += async () =>
        {
            SoundManager.Instance.PlaySE("Click_Button");
            SceneManager.LoadScene("Title");
            await UniTask.WaitForSeconds(0.3f, ignoreTimeScale: true);
            UnityEngine.Time.timeScale = 1;
        };

        retryButton.ButtonActions.OnButtonClick += async () =>
        {
            SoundManager.Instance.PlaySE("Click_Button");
            SceneManager.LoadScene("LoadScene");
            await UniTask.WaitForSeconds(0.3f, ignoreTimeScale: true);
            UnityEngine.Time.timeScale = 1;
        };

        tweetButton.ButtonActions.OnButtonClick += () =>
        {
            SoundManager.Instance.PlaySE("Click_Button");
            naichilab.UnityRoomTweet.Tweet(tweetInfo.GameId, $"{tweetInfo.TweetContent}\n{tweetInfo.HashTag}");
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
