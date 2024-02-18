using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "BlockKnight/PlayerInfo", order = 1)]
public class PlayerInfo : ScriptableObject
{
    [Header("ステータス関連"), Space(3)]
    [SerializeField, Header("最大スタミナ")]
    private float maxStamina = 100f;
    public float MaxStamina => maxStamina;

    [SerializeField, Header("スタミナの回復間隔")]
    private float staminaRecoveryIntervalSec = 0.1f;
    public float StaminaRecoveryIntervalSec => staminaRecoveryIntervalSec;
    [SerializeField, Header("スタミナの回復間隔経過ごとの回復量")]
    private float staminaRecoveryValue = 0.1f;
    public float StaminaRecoveryValue => staminaRecoveryValue;
    [Header("移動関連"), Space(3)]
    [SerializeField, Header("移動速度")]
    private float moveSpeed = 10f;
    public float MoveSpeed => moveSpeed;
    [SerializeField, Header("慣性")]
    private float inertia = 0.5f;
    public float Inertia => inertia;

    [Header("ジャンプ関連"), Space(3)]
    [SerializeField, Header("重力の強さ")]
    private float gravityScale = 1f;
    public float GravityScale => gravityScale;
    [SerializeField, Header("ジャンプの最大到達点の高さ")]
    private float maxJumpHeight = 10f;
    public float MaxJumpHeight => maxJumpHeight;
    [SerializeField, Header("ジャンプの最小到達点の高さ")]
    private float minJumpHeight = 5f;
    public float MinJumpHeight => minJumpHeight;
    [SerializeField, Header("最大到達点に達するまでの時間")]
    private float timeToJumpApex = 0.5f;
    public float TimeToJumpApex => timeToJumpApex;

    [Header("攻撃関連"), Space(3)]
    [SerializeField, Header("通常攻撃の攻撃力")]
    private float attackPower = 1f;
    public float AttackPower => attackPower;
    [SerializeField, Header("溜め攻撃の攻撃力")]
    private float chargeAttackPower = 2f;
    public float ChargeAttackPower => chargeAttackPower;
    [SerializeField, Header("攻撃がコアに与える加速度")]
    private float attackAcceleration = 30f;
    public float AttackAcceleration => attackAcceleration;
    [SerializeField, Header("溜め攻撃がコアに与える加速度")]
    private float chargeAttackAcceleration = 50f;
    public float ChargeAttackAcceleration => chargeAttackAcceleration;
    [SerializeField, Header("再度攻撃可能になるまでのインターバル")]
    private float attackIntervalSec = 0.5f;
    public float AttackIntervalSec => attackIntervalSec;
    [SerializeField, Header("攻撃に必要なスタミナ量")]
    private float attackStamina = 10f;
    public float AttackStamina => attackStamina;
    [SerializeField, Header("溜め攻撃に必要なスタミナ量")]
    private float chargeAttackStamina = 10f;
    public float ChargeAttackStamina => chargeAttackStamina;
    [SerializeField, Header("溜め攻撃のチャージが完了するまでの時間")]
    private float chargeSec = 3;
    public float ChargeSec => chargeSec;
    [SerializeField, Header("攻撃判定が消えるまでの時間")]
    private float attackActiveSec = 0.1f;
    public float AttackActiveSec => attackActiveSec;
    [SerializeField, Header("攻撃がコアにヒットした時のヒットストップの時間")]
    private float hitStopSec = 0.1f;
    public float HitStopSec => hitStopSec;
    [SerializeField, Header("溜め攻撃がコアにヒットした時のヒットストップの時間")]
    private float chargeHitStopSec = 0.3f;
    public float ChargeHitStopSec => chargeHitStopSec;


    [Header("被ダメ関連"), Space(3)]
    [SerializeField, Header("被ダメ時の減速量")]
    private float onHitSpeedDownValue = 0.5f;
    public float OnHitSpeedDownValue => onHitSpeedDownValue;
    [SerializeField, Header("被ダメ時の点滅回数")]
    private int onHitBlinkNum = 5;
    public int OnHitBlinkNum => onHitBlinkNum;
}
