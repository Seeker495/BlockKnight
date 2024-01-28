using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingAnimation : MonoBehaviour, IAnimation
{
    public void Play()
    {
        TryGetComponent(out Animator animator);

        animator.SetTrigger("Jump");
    }
}
