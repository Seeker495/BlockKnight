using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAnimation : MonoBehaviour, IAnimation
{
    public void Play()
    {
        TryGetComponent(out Animator animator);

        animator.SetBool("noBlood", true);
        animator.SetTrigger("Death");
    }

}
