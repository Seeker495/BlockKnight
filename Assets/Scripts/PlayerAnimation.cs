using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

enum eAnimation
{
    STANDING,
    RUNNING,
    JUMPING,
    ATTACK,
    BLOCK,
}

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMover mMover;
    [SerializeField] private PlayerAttacker mAttacker;

    eAnimation mAnim;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out mMover);
        TryGetComponent(out mAttacker);
    }

    // Update is called once per frame
    void Update()
    {
        IAnimation animation;

        if (mAttacker.IsAttack())
            animation = GetComponent<AttackAnimation>();

        else if (mMover.IsFalling())
            animation = GetComponent<FallingAnimation>();
        else if (mMover.IsMove() && !mMover.IsJumping())
            animation = GetComponent<RunningAnimation>();
        else
            animation = GetComponent<StandingAnimation>();

        if(mMover.IsJumping())
            animation = GetComponent<JumpingAnimation>();


        animation.Play();


        transform.localScale = new Vector2(mMover.GetDirection(), 1f);

    }
}
