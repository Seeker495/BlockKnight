using UniRx;
using UnityEngine;
using AsciiUtil;

public class TimerPresenter : MonoBehaviour
{
    [SerializeField]
    private TimerView timerView;
    [SerializeField]
    private GameEvent playerDeathEvent;
    private TimerModel timerModel;
    public ReadOnlyReactiveProperty<float> CurrentTime => timerModel.CurrentTime;

    private void Start()
    {
        Initialize();
        StartTimer();
    }

    private void Initialize()
    {
        timerModel = new TimerModel();
        CurrentTime.Subscribe(value => timerView.TimerTextUpdate(value)).AddTo(this);
        timerModel.IsTimerEnd.Where(isEnd => isEnd).Subscribe(_ => playerDeathEvent.Raise()).AddTo(this);
    }

    public void StartTimer()
    {
        timerModel.StartTimer();
    }

    public void StopTimer()
    {
        timerModel.StopTimer();
    }

    public void ResetTimer()
    {
        timerModel.ResetTimer();
    }
}
