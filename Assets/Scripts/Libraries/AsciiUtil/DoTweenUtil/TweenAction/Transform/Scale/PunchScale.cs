using UnityEngine;
using DG.Tweening;
namespace AsciiUtil
{
    [System.Serializable, AddTypeMenu("Transform/Scale/PunchScale")]
    public class PunchScale : TweenAction
    {
        [SerializeField, Header("振動の強さ")]
        private Vector3 punchStrength;
        [SerializeField, Header("振動の回数")]
        private int shakeNum;

        public override Tween Play(Transform transform)
        {
            return transform.DOPunchScale(Vector3.one * 0.1f, tweenParameter.Duration, shakeNum)
            .SetEase(tweenParameter.Ease)
            .SetUpdate(tweenParameter.IsIgnoreTimeScale)
            .OnKill(() => transform.localScale = Vector3.one);
        }
    }
}