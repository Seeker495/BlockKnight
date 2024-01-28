using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingAnimation : MonoBehaviour, IAnimation
{
    public void Play()
    {
        TryGetComponent(out Animator animator);
        TryGetComponent(out Rigidbody2D rb);
        animator.SetFloat("AirSpeedY", rb.velocity.y);
    }
}
