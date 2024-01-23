using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

public class CoreSpeedPresenter : MonoBehaviour
{
    [SerializeField]
    private CoreSpeedView coreSpeedView;
    [SerializeField]
    private CoreSpeedController coreSpeedModel;
    public ReadOnlyReactiveProperty<float> CurrentSpeed => coreSpeedModel.CurrentSpeed;
    public UnityAction<float> onColorChanged { get; set; }

    private async void Start()
    {
        await UniTask.DelayFrame(1);
        Initialize();
    }

    void Initialize()
    {
        CurrentSpeed.Subscribe(value =>
        {
            coreSpeedView.UpdateCoreSpeed(value);
            onColorChanged?.Invoke(value);
        }).AddTo(this);
    }
}
