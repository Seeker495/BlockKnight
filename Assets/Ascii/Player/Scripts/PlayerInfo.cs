using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "BlockKnight/PlayerInfo", order = 1)]
public class PlayerInfo : ScriptableObject
{
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

}
