using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CoreSpeedModel : MonoBehaviour
{
    private SpriteRenderer mSpriteRenderer;
    private FloatReactiveProperty mSpeed;
    // Start is called before the first frame update
    void Start()
    {
        mSpeed = new FloatReactiveProperty();
        TryGetComponent(out mSpriteRenderer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
