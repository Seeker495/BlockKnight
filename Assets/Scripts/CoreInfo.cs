using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CoreInfo")]
public class CoreInfo : ScriptableObject
{
    [Tooltip("ç≈çÇë¨ìx")]
    public float MAX_SPEED { get; }

    [Tooltip("ïbä‘")]
    public float IN_TIME { get; }

    [Tooltip("ïbä‘ÇÃå∏ë¨")]
    public float DECREASE_SPEED { get; }

}