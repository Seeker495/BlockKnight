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

    [SerializeField, Header("表示用の最低速度")]
    private float displayMinSpeed;
    public float DisplayMinSpeed => displayMinSpeed;
    [SerializeField, Header("表示用の最高速度")]
    private float displayMaxSpeed;
    public float DisplayMaxSpeed => displayMaxSpeed;

    [SerializeField, Header("低速時の色")]
    private Color lowSpeedColor;
    public Color LowSpeedColor => lowSpeedColor;
    [SerializeField, Header("高速時の色")]
    private Color highSpeedColor;
    public Color HighSpeedColor => highSpeedColor;

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
    [Space(10), Header("フィーバー")]
    [SerializeField, Header("フィーバーになるのに必要なスピード維持時間(秒)")]
    private float feverNeedTime;
    public float FeverNeedTime => feverNeedTime;
    [SerializeField, Header("フィーバーの持続時間(秒)")]
    private float feverTime;    
    public float FeverTime => feverTime;
}