using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    private GameController gameController;
    private PlayerAnimationController animationController;
    private Rigidbody2D rigidBody;
    private PlayerInfo playerInfo;
    private bool isJumping;
    private bool isGrounded = true;
    private float jumpStartTime;

    public void Initialize(Player player)
    {
        gameController = player.GameController;
        rigidBody = player.RigidBody;
        playerInfo = player.PlayerInfo;
        animationController = player.AnimationController;
        rigidBody.gravityScale = playerInfo.GravityScale;
        gameController.Player.Jump.performed += _ => StartJump();
        gameController.Player.Jump.canceled += _ => EndJump();
    }
    void Update()
    {
        CheckGrounded();
        if (!isJumping) return;
        ContinueJump();
    }

    private void StartJump()
    {
        if (!isGrounded) return;
        SoundManager.Instance.PlaySE("Player_Jump");
        isJumping = true;
        animationController.SetIsJumping(true);
        jumpStartTime = Time.time;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, CalculateJumpVelocity(playerInfo.MinJumpHeight));
    }

    private void ContinueJump()
    {
        if (Time.time < jumpStartTime + playerInfo.TimeToJumpApex)
        {
            float elapsedTime = Time.time - jumpStartTime;
            float proportionalHeight = Mathf.Lerp(playerInfo.MinJumpHeight, playerInfo.MaxJumpHeight, elapsedTime / playerInfo.TimeToJumpApex);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, CalculateJumpVelocity(proportionalHeight));
        }
        else
        {
            EndJump();
        }
    }

    private void EndJump()
    {
        isJumping = false;
        animationController.SetIsJumping(false);
    }

    private float CalculateJumpVelocity(float jumpHeight)
    {
        return Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y * rigidBody.gravityScale));
    }

    private void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        isGrounded = hit.collider != null;
        if (isGrounded)
        {
            animationController.SetIsGrounded(true);
            return;
        }
        animationController.SetIsGrounded(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.1f);
    }
}
