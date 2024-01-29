using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerMover playerMover;
    [SerializeField]
    private PlayerJumper playerJumper;

    private PlayerInfo playerInfo;
    public PlayerInfo PlayerInfo => playerInfo;
    private GameController gameController;
    public GameController GameController => gameController;
    private Rigidbody2D rigidBody;
    public Rigidbody2D RigidBody => rigidBody;
    private PlayerAnimationController animationController;
    public PlayerAnimationController AnimationController => animationController;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animationController = GetComponent<PlayerAnimationController>();
        playerInfo = InfomationProvider.Instance.PlayerInfo;
        gameController = new GameController();
        gameController.Enable();

        playerMover.Initialize(this);
        playerJumper.Initialize(this);
    }
}
