using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeAdjustWindowController : MonoBehaviour
{
    [SerializeField]
    private Slider masterVolumeSlider;
    [SerializeField]
    private TextMeshProUGUI masterVolumeText;
    [SerializeField]
    private Slider bgmVolumeSlider;
    [SerializeField]
    private TextMeshProUGUI bgmVolumeText;
    [SerializeField]
    private Slider seVolumeSlider;
    [SerializeField]
    private TextMeshProUGUI seVolumeText;

    private SoundManager soundManager;

    void Start()
    {
        soundManager = SoundManager.Instance;
        //スライダーの初期値設定
        masterVolumeSlider.value = soundManager.MasterVolumeMultiply.Value;
        bgmVolumeSlider.value = soundManager.BGMVolumeMultiply.Value;
        seVolumeSlider.value = soundManager.SEVolumeMultiply.Value;
        //テキストの初期値設定
        masterVolumeText.text = GetPercentageText(masterVolumeSlider.value);
        bgmVolumeText.text = GetPercentageText(bgmVolumeSlider.value);
        seVolumeText.text = GetPercentageText(seVolumeSlider.value);

        //各種スライダーの値変更時処理
        masterVolumeSlider.onValueChanged.AddListener((value) =>
        {
            soundManager.SetMasterVolumeMultiply(value);
            masterVolumeText.text = GetPercentageText(value);
        });

        bgmVolumeSlider.onValueChanged.AddListener((value) =>
        {
            soundManager.SetBGMVolumeMultiply(value);
            bgmVolumeText.text = GetPercentageText(value);
        });

        seVolumeSlider.onValueChanged.AddListener((value) =>
        {
            soundManager.SetSEVolumeMultiply(value);
            seVolumeText.text = GetPercentageText(value);
        });
    }

    private string GetPercentageText(float value)
    {
        int percentage = (int)(value * 100);
        return $"{percentage}%";
    }
}
