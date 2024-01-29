using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private PlayerAnimationController animationController;
    private GameController gameController;
    private Rigidbody2D rigidBody;
    private Vector2 horizontalDirection = Vector2.zero;
    private Vector2 currentVelocity = Vector2.zero;

    public void Initialize(Player player)
    {
        rigidBody = player.RigidBody;
        animationController = player.AnimationController;
        playerInfo = player.PlayerInfo;
        gameController = player.GameController;
        gameController.Player.Move.performed += value => ChangeDirection(value.ReadValue<Vector2>());
        gameController.Player.Move.canceled += _ => ChangeDirection(Vector2.zero);
        gameController.Enable();
    }

    private void ChangeDirection(Vector2 value)
    {
        horizontalDirection = value;
        animationController.SetHorizontalVelocity(value);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 targetVelocity = horizontalDirection * playerInfo.MoveSpeed;
        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, playerInfo.Inertia);
        rigidBody.velocity = new Vector2(currentVelocity.x, rigidBody.velocity.y);

        if (Mathf.Approximately(playerInfo.Inertia, 0f))
        {
            rigidBody.velocity = new Vector2(targetVelocity.x, rigidBody.velocity.y);
        }
    }
}
