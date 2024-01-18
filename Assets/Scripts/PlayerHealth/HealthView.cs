using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;

public class HealthView : MonoBehaviour
{
    [SerializeField, Header("HP変動時のアニメーション速度(秒)")]
    private float displayUpdateDurationSec = 0.5f;
    [SerializeField, Header("HP変動時のアニメーションのイージング")]
    private Ease displayUpdateEase = Ease.OutQuad;
    [SerializeField]
    private HealthImageFillController healthImagePrefab;
    [SerializeField]
    private List<HealthImageFillController> healthImages = new List<HealthImageFillController>();
    private float displayHealth;
    const float FILL_MAX = 1;
    const float FILL_MIN = 0;

    /// <summary>
    /// HP最大値変更時の処理
    /// </summary>
    /// <param name="maxHealth"></param>
    public void HealthImageCountUpdate(float maxHealth)
    {
        //HP表示数がHP最大値より足りない場合の処理
        if (healthImages.Count < (int)maxHealth)
        {
            //HP表示数が足りない場合
            for (int i = healthImages.Count; i < (int)maxHealth; i++)
            {
                var healthImage = Instantiate(healthImagePrefab, transform);
                healthImages.Add(healthImage);
            }
        }

        //HP表示数がHP最大値より多い場合の処理
        if (healthImages.Count > (int)maxHealth)
        {
            //HP表示数が多い場合
            for (int i = healthImages.Count - 1; i >= (int)maxHealth; i--)
            {
                healthImages.RemoveAt(i);
                Destroy(healthImages[i].gameObject);
            }
        }
    }

    public void UpdateHealth(float newHealth)
    {
        // DoTweenを使用してdisplayHealthをnewHealthまで滑らかに変更
        DOTween.To(() => displayHealth, x => displayHealth = x, newHealth, displayUpdateDurationSec)
        .SetEase(displayUpdateEase)
        .OnUpdate(() =>
        {
            HealthViewUpdate(displayHealth);
        });
    }

    /// <summary>
    /// HPの値が変わった時の見た目の更新処理
    /// </summary>
    /// <param name="health"></param>
    private void HealthViewUpdate(float health)
    {
        //一旦全てのハートをリセット
        foreach (var healthImage in healthImages)
        {
            healthImage.HealthImageFillUpdate(FILL_MIN);
        }

        //完全に満たされたハートを更新
        int fullHearts = Mathf.FloorToInt(health);
        for (int i = 0; i < fullHearts; i++)
        {
            healthImages[i].HealthImageFillUpdate(FILL_MAX);
        }

        //部分的に満たされたハートがあれば更新
        if (health > fullHearts && fullHearts < healthImages.Count)
        {
            var partialFill = health - fullHearts;
            healthImages[fullHearts].HealthImageFillUpdate(partialFill);
        }
    }
}
