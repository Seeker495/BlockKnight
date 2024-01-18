using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthImageFillController : MonoBehaviour
{
    [SerializeField]
    private Image healthFillImage;
    /// <summary>
    /// HPの値が変わった時の処理
    /// </summary>
    /// <param name="imageFillAmount"></param>
    public void HealthImageFillUpdate(float imageFillAmount)
    {
        healthFillImage.fillAmount = imageFillAmount;
    }
}
