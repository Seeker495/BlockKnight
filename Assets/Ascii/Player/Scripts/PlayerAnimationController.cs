using UniRx;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Vector2 initialScale;

    void Start()
    {
        animator = GetComponent<Animator>();
        initialScale = transform.localScale;
    }

    public void SetHorizontalVelocity(Vector2 value)
    {
        animator.SetFloat("HorizontalVelocity", Mathf.Abs(value.x));
        CheckAndChangeDirection(value.normalized);
    }

    public void SetAttacking(bool value)
    {
        animator.SetBool("IsAttacking", value);
    }

    public void SetIsJumping(bool value)
    {
        animator.SetBool("IsJumping", value);
    }

    public void SetIsGrounded(bool value)
    {
        animator.SetBool("IsGrounded", value);
    }

    private void CheckAndChangeDirection(Vector2 value)
    {
        if (value.x == 0f) return;
        transform.localScale = initialScale * new Vector2(value.x, 1);
    }
}
