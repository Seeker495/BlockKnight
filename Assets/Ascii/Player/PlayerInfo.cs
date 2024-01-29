using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "BlockKnight/PlayerInfo", order = 1)]
public class PlayerInfo : ScriptableObject
{
    [SerializeField, Header("移動速度")]
    private float moveSpeed = 10f;
    public float MoveSpeed => moveSpeed;
    [SerializeField, Header("慣性")]
    private float inertia = 0.5f;
    public float Inertia => inertia;

}
