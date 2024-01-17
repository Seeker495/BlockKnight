using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMover mMover;
    [SerializeField] private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out mMover);
        TryGetComponent(out mAnimator);
    }

    // Update is called once per frame
    void Update()
    {
        if (mMover.IsMove())
        {
            mAnimator.SetInteger("AnimState", 1);
            mAnimator.SetBool("Grounded", true);
        }
        else
        {
            mAnimator.SetInteger("AnimState", 0);
            mAnimator.SetBool("Grounded", true);
        }
        transform.localScale = new Vector2(mMover.GetDirection(), 1f);

    }
}
