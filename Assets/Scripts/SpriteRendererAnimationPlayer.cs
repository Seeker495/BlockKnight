using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.UI;

public class SpriteRendererAnimationPlayer : MonoBehaviour
{
    [SerializeField, Header("再生するスプライト")]
    private Sprite[] sprites;
    [SerializeField, Header("再生にかかる秒数")]
    private float durationSec;
    [SerializeField]
    private bool isLoop = false;
    [SerializeField]
    private SpriteRenderer image;

    private BoolReactiveProperty isDone;
    public IReadOnlyReactiveProperty<bool> IsDone => isDone.ToReadOnlyReactiveProperty();
    private float perSpriteDurationSec;
    private int currentSpriteIndex = 0;
    private CancellationTokenSource cts;


    /// <summary>
    /// 再生を開始します
    /// </summary> <summary>
    public void Play()
    {
        perSpriteDurationSec = durationSec / sprites.Length;
        cts = new CancellationTokenSource();
        isDone = new BoolReactiveProperty(false);
        AnimationUpdate(cts.Token);
    }

    /// <summary>
    /// 再生を一時停止します
    /// </summary>
    public void Pause()
    {
        StopAnimation();
    }

    /// <summary>
    /// 再生を停止します
    /// </summary>
    public void Stop()
    {
        StopAnimation();
        currentSpriteIndex = 0;
    }

    public void ChangePerSpriteDuration(float duration)
    {
        perSpriteDurationSec = duration;
        StopAnimation();
        Play();
    }

    private async void AnimationUpdate(CancellationToken token)
    {
        while (token.IsCancellationRequested == false)
        {
            // 画像を切り替える
            image.sprite = sprites[currentSpriteIndex];
            // 次の画像に切り替えるまで待機
            await UniTask.Delay(System.TimeSpan.FromSeconds(perSpriteDurationSec), cancellationToken: token);
            //次インデックスへ更新
            currentSpriteIndex = isLoop ? (currentSpriteIndex + 1) % sprites.Length : currentSpriteIndex + 1;
            // インデックスがスプライトの数を超えたら終了
            if (currentSpriteIndex < sprites.Length) continue;
            StopAnimation();
            currentSpriteIndex = 0;
            Destroy(gameObject);
        }
    }

    private void StopAnimation()
    {
        image.sprite = null;
        isDone.Value = true;
        cts.Cancel();
    }
}
