using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out Animations animations);
        Debug.Log(animations);
        animations.Play("Attack");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
