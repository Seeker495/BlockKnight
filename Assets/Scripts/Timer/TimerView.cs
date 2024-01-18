using UnityEngine;
using TMPro;

public class TimerView : MonoBehaviour
{
    [SerializeField, Header("タイマーの小数点以下の桁数")]
    private int timerDigit = 2;
    [SerializeField]
    private TextMeshProUGUI timerText;

    public void TimerTextUpdate(float timer)
    {
        timerText.text = timer.ToString($"F{timerDigit}");
    }
}
