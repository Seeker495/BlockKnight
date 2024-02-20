using System.Collections;
using System.Collections.Generic;
using AsciiUtil;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private CoreSpeedController coreSpeedController;
    [SerializeField]
    private GameEvent gameOverEvent;
    [SerializeField]
    private Canvas canvas;
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


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }
    }

    private void OnBecameInvisible()
    {
        gameOverEvent.Raise();
    }

    public void Damage()
    {
        SoundManager.Instance.PlaySE("Player_Damage");
        Blink().Forget();
        coreSpeedController.DecreaseSpeed(playerInfo.OnHitSpeedDownValue);
    }
    private async UniTaskVoid Blink()
    {
        await spriteRenderer.DOFade(0, 0.1f).SetLoops(playerInfo.OnHitBlinkNum, LoopType.Yoyo).AsyncWaitForCompletion();
        spriteRenderer.DOFade(1, 0);
    }
}
