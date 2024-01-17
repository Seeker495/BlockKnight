using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UIElements;

public class CameraMover : MonoBehaviour
{
    [Tooltip("�Ǐ]�Ώ�"), SerializeField] private Transform mTarget;
    [Tooltip("�I�t�Z�b�g(�c����)"), SerializeField] private float mOffsetY;
    // Start is called before the first frame update
    void Start()
    {
        if (mTarget == null)
        {
            Debug.Log("CameraMover: No Setting Target!");
            return;
        }
        Observable.EveryLateUpdate().Subscribe(_ => { transform.position = new Vector3(mTarget.position.x, mTarget.position.y + mOffsetY, transform.position.z); }).AddTo(this);
    }

}
