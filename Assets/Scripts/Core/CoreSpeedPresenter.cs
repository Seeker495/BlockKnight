using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CoreSpeedPresenter : MonoBehaviour
{
    [SerializeField]
    private CoreSpeedView coreSpeedView;
    [SerializeField]
    private CoreSpeedController coreSpeedModel;
    public ReadOnlyReactiveProperty<float> CurrentSpeed => coreSpeedModel.CurrentSpeed;

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
        }).AddTo(this);
    }
}
