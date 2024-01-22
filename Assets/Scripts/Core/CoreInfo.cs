using UnityEngine;

[CreateAssetMenu(fileName = "CoreInfo", menuName = "BlockKnight/CoreInfo")]
public class CoreInfo : ScriptableObject
{
    [SerializeField, Header("最高速度")]
    private float maxSpeed;
    public float MaxSpeed => maxSpeed;

    [SerializeField, Header("最低速度")]
    private float minSpeed;
    public float MinSpeed => minSpeed;

    [SerializeField, Header("初期速度")]
    private float initialSpeed;
    public float InitialSpeed => initialSpeed;

    [SerializeField, Header("ブロック衝突時の加速量")]
    private float onHitBlockSpeedUpValue;
    public float OnHitBlockSpeedUpValue => onHitBlockSpeedUpValue;

    [SerializeField, Header("速度減少のインターバル(秒)")]
    private float speedDecreaseInterval;
    public float SpeedDecreaseInterval => speedDecreaseInterval;

    [SerializeField, Header("速度減少量")]
    private float speedDecreaseValue;
    public float SpeedDecreaseValue => speedDecreaseValue;


    [Space(10), Header("クローン")]
    [SerializeField, Header("クローンの速度")]
    private float cloneSpeed;
    public float CloneSpeed => cloneSpeed;

    [SerializeField, Header("クローンが消えるまでの時間(秒)")]
    private float cloneLifeTimeSec;
    public float ClonellifeTimeSec => cloneLifeTimeSec;

}