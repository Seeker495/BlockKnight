using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningAnimation : MonoBehaviour, IAnimation
{
    public void Play()
    {
        TryGetComponent(out Animator animator);

        animator.SetInteger("AnimState", 1);
        animator.SetBool("Grounded", true);
    }

}
