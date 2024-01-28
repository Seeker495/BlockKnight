using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DeadEvent : MonoBehaviour
{
    public IObservable<Unit> OnDead { get { return onDeadEvent; }  }
    Subject<Unit> onDeadEvent = new Subject<Unit>();

    public void Dead(bool condition = true)
    {
        if(condition)
        onDeadEvent.OnNext(Unit.Default);
    }
}
