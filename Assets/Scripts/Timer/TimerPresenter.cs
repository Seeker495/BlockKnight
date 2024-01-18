using UniRx;
using UnityEngine;

public class TimerPresenter : MonoBehaviour
{
    [SerializeField]
    private TimerView timerView;
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
