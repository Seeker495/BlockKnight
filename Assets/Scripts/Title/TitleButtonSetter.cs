using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsciiUtil.UI;

public class TitleButtonSetter : MonoBehaviour
{
    [SerializeField, Header("プレイ")]
    private AsciiButton playButton;
    [SerializeField]
    private string playSceneName;
    [SerializeField, Header("操作説明")]
    private AsciiButton howToPlayButton;
    [SerializeField]
    private AsciiPopupWindow howToPlayPopupWindow;
    [SerializeField, Header("ランキング")]
    private AsciiButton rankingButton;
    [SerializeField]
    private AsciiPopupWindow rankingPopupWindow;
    [SerializeField, Header("サウンド調整")]
    private AsciiButton soundVolumeAdjustButton;
    [SerializeField]
    private AsciiPopupWindow soundVolumeAdjustPopupWindow;
    [SerializeField, Header("クレジット")]
    private AsciiButton creditButton;
    [SerializeField]
    private AsciiPopupWindow creditPopupWindow;


    private void Start()
    {
        //プレイボタン押下時処理
        playButton.ButtonActions.OnButtonClick += () =>
        {
            //シーン読み込み
            //SceneLoader.Instance.LoadScene(playSceneName);
        };

        //操作説明ボタン押下時処理
        howToPlayButton.ButtonActions.OnButtonClick += () =>
        {
            howToPlayPopupWindow.OpenPopupWindow();
        };

        //ランキングボタン押下時処理
        rankingButton.ButtonActions.OnButtonClick += () =>
        {
            rankingPopupWindow.OpenPopupWindow();
        };

        //サウンド調整ボタン押下時処理
        soundVolumeAdjustButton.ButtonActions.OnButtonClick += () =>
        {
            soundVolumeAdjustPopupWindow.OpenPopupWindow();
        };

        //クレジットボタン押下時処理
        creditButton.ButtonActions.OnButtonClick += () =>
        {
            creditPopupWindow.OpenPopupWindow();
        };
    }

}
