using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingAnimation : MonoBehaviour, IAnimation
{

    public void Play()
    {
        TryGetComponent(out Animator animator);

        animator.SetInteger("AnimState", 0);
        animator.SetBool("Grounded", true);

    }
}
