using UnityEngine;

[CreateAssetMenu(fileName = "BlockGoremInfo", menuName = "BlockKnight/BlockGoremInfo")]
public class BlockGoremInfo : ScriptableObject
{
    [SerializeField, Header("死亡判定/ブロックの破壊割合")]
    private float destroyedBlockRatio;
    public float DestroyedBlockRatio => destroyedBlockRatio;
    [SerializeField, Header("最短間隔")]
    private float minInterval;
    public float MinInterval => minInterval;

    [SerializeField, Header("最長間隔")]
    private float maxInterval;
    public float MaxInterval => maxInterval;
    [SerializeField, Header("剣の攻撃後の硬直時間")]
    private float swordAttackStiffness;
    public float SwordAttackStiffness => swordAttackStiffness;

    [SerializeField, Header("ラッシュ攻撃時の硬直時間")]
    private float rushAttackStiffness;
    public float RushAttackStiffness => rushAttackStiffness;

}