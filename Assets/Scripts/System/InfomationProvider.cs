using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfomationProvider : SingletonMonoBehaviour<InfomationProvider>
{
    [SerializeField]
    private CoreInfo coreInfo;
    public CoreInfo CoreInfo => coreInfo;
}
