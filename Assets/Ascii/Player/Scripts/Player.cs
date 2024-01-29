using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerMover playerMover;
    [SerializeField]
    private PlayerJumper playerJumper;
    [SerializeField]
    private PlayerAttacker playerAttacker;
    [SerializeField]
    private AttackAreaController attackAreaController;
    public AttackAreaController AttackAreaController => attackAreaController;
    private PlayerInfo playerInfo;
    public PlayerInfo PlayerInfo => playerInfo;
    private GameController gameController;
    public GameController GameController => gameController;
    private Rigidbody2D rigidBody;
    public Rigidbody2D RigidBody => rigidBody;
    private PlayerAnimationController animationController;
    public PlayerAnimationController AnimationController => animationController;
    private StaminaPresenter staminaPresenter;
    public StaminaPresenter StaminaPresenter => staminaPresenter;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animationController = GetComponent<PlayerAnimationController>();
        staminaPresenter = GetComponent<StaminaPresenter>();
        playerInfo = InfomationProvider.Instance.PlayerInfo;
        gameController = new GameController();
        gameController.Enable();

        staminaPresenter.Initialize(playerInfo.MaxStamina);
        attackAreaController.Initialize(playerInfo);
        playerMover.Initialize(this);
        playerJumper.Initialize(this);
        playerAttacker.Initialize(this);
    }
}
