using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private GameController gameController;
    private StaminaPresenter staminaPresenter;
    private PlayerAnimationController animationController;
    private AttackAreaController attackAreaController;
    private bool isCharging = false;
    private bool isChargeCompleted = false;
    private bool isFinishAttackInterval = true;
    private CancellationTokenSource chargeCts;

    public void Initialize(Player player)
    {
        playerInfo = player.PlayerInfo;
        gameController = player.GameController;
        staminaPresenter = player.StaminaPresenter;
        animationController = player.AnimationController;
        attackAreaController = player.AttackAreaController;
        gameController.Player.Attack.performed += _ => StartCharging().Forget();
        gameController.Player.Attack.canceled += _ => Attack();

        StaminaRecovery();
    }
    private async void StaminaRecovery()
    {
        while (true)
        {
            await UniTask.WaitForSeconds(playerInfo.StaminaRecoveryIntervalSec);
            if (isCharging) continue;
            staminaPresenter.IncreaseStamina(playerInfo.StaminaRecoveryValue);
        }
    }

    private async UniTaskVoid StartCharging()
    {
        if (!isFinishAttackInterval) return;
        chargeCts = new CancellationTokenSource();
        isChargeCompleted = false;
        isCharging = true;
        await UniTask.WaitForSeconds(playerInfo.ChargeSec, cancellationToken: chargeCts.Token);
        isChargeCompleted = true;
    }

    private async void Attack()
    {
        chargeCts.Cancel();
        if (!isFinishAttackInterval) return;

        bool canAttack = isChargeCompleted ? staminaPresenter.CanAttack(playerInfo.ChargeAttackStamina) : staminaPresenter.CanAttack(playerInfo.AttackStamina);
        if (!canAttack)
        {
            isCharging = false;
            return;
        }

        isFinishAttackInterval = false;
        staminaPresenter.DecreaseStamina(isChargeCompleted ? playerInfo.ChargeAttackStamina : playerInfo.AttackStamina);
        animationController.SetAttacking(true);
        attackAreaController.Active(isChargeCompleted);

        await UniTask.WaitForSeconds(playerInfo.AttackActiveSec);
        attackAreaController.Disable();
        animationController.SetAttacking(false);
        isChargeCompleted = false;
        isCharging = false;

        await UniTask.WaitForSeconds(playerInfo.AttackIntervalSec);
        isFinishAttackInterval = true;
    }

}
