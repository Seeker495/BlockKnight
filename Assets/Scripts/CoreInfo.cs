using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CoreInfo")]
public class CoreInfo : ScriptableObject
{
    [Tooltip("�ō����x")]
    public float MAX_SPEED { get; }

    [Tooltip("�b��")]
    public float IN_TIME { get; }

    [Tooltip("�b�Ԃ̌���")]
    public float DECREASE_SPEED { get; }

}