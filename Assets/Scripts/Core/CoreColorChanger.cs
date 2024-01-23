using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CoreColorChanger : MonoBehaviour
{
    private CoreInfo coreInfo;
    private SpriteRenderer spriteRenderer;
    private CoreSpeedPresenter coreSpeedPresenter;
    void Start()
    {
        coreInfo = InfomationProvider.Instance.CoreInfo;
        spriteRenderer = GetComponent<SpriteRenderer>();
        coreSpeedPresenter = GetComponent<CoreSpeedPresenter>();

        coreSpeedPresenter.onColorChanged += speed =>
        {
            float normalized = (speed - coreInfo.MinSpeed) / (coreInfo.MaxSpeed - coreInfo.MinSpeed);
            spriteRenderer.color = Color.Lerp(coreInfo.LowSpeedColor, coreInfo.HighSpeedColor, normalized);
        };
    }
}
