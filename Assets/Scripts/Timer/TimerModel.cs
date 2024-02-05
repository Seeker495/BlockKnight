using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class TimerModel
{
    private ReactiveProperty<float> currentTime = new ReactiveProperty<float>(0);
    public ReadOnlyReactiveProperty<float> CurrentTime => currentTime.ToReadOnlyReactiveProperty();
    private CancellationTokenSource timerCTS;

    public BoolReactiveProperty IsTimerEnd { get; } = new BoolReactiveProperty(false);

    public TimerModel(int initialTime = 0)
    {
        currentTime = new ReactiveProperty<float>(initialTime);
    }
    public void StartTimer()
    {
        timerCTS = new CancellationTokenSource();
        UpdateTimer(timerCTS);
    }

    public void StopTimer()
    {
        timerCTS.Cancel();
    }

    public void ResetTimer()
    {
        currentTime.Value = 0;
    }

    public async void UpdateTimer(CancellationTokenSource timerCTS)
    {
        while (timerCTS.IsCancellationRequested == false)
        {
            await UniTask.Yield(PlayerLoopTiming.Update);
            currentTime.Value -= Time.deltaTime;

            if (currentTime.Value <= 0)
            {
                IsTimerEnd.Value = true;
                timerCTS.Cancel();
            }
        }
    }
}
