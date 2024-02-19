using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    private AsciiButton nextButton;
    [SerializeField]
    private Image tutorialImage;
    [SerializeField]
    private Sprite[] tutorialSprites;
    [SerializeField]
    private string nextSceneName;
    private int currentTutorialIndex = 0;
    void Start()
    {
        nextButton.ButtonActions.OnButtonClick += () =>
        {
            currentTutorialIndex++;
            if (currentTutorialIndex >= tutorialSprites.Length)
            {
                //シーン読み込み
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                tutorialImage.sprite = tutorialSprites[currentTutorialIndex];
            }
        };
    }
}
