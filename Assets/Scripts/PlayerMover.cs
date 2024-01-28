using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    GameController mController;
    private Rigidbody2D mRigidbody2D;
    public Rigidbody2D Rigidbody2D => mRigidbody2D;
    private bool mIsMove;
    private float mDirection;
    private bool mIsFalling;
    public float GetDirection() { return mDirection; }
    public bool IsMove() { return  mIsMove; }
    private bool mIsJumping;
    public bool IsJumping() { return mIsJumping; }

    public bool IsFalling() { return mIsFalling; }
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out mRigidbody2D);
        mController = new GameController();
        mController.Player.Move.performed += Move;
        mController.Player.Move.canceled += Move;
        mController.Player.Jump.performed += Jump;
        mController.Enable();
        mDirection = 1f;
        mIsFalling = mRigidbody2D.velocity.y < 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>().normalized;
        mRigidbody2D.velocity = move * 10;
        if (move.x == 0f)
        {
            mIsMove = false;
            return;
        }
        mDirection = move.x;
        mIsMove = true;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        mRigidbody2D.AddForce(10 * Vector2.up, ForceMode2D.Impulse);
        mIsJumping = true;
    }



}
