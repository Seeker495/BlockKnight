using UniRx;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private FloatReactiveProperty horizontalVelocity = new FloatReactiveProperty(0f);
    void Start()
    {
        animator = GetComponent<Animator>();


        horizontalVelocity.Subscribe(value => animator.SetFloat("HorizontalVelocity", value)).AddTo(this);
    }

    public void SetHorizontalVelocity(Vector2 value)
    {
        horizontalVelocity.Value = Mathf.Abs(value.x);
        CheckAndChangeDirection(value.normalized);
    }

    private void CheckAndChangeDirection(Vector2 value)
    {
        if (value.x == 0f) return;
        transform.localScale = new Vector3(value.x, 1f, 1f);
    }
}
