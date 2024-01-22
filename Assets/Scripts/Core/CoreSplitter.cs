using AsciiUtil;
using AsciiUtil.ScriptableSystem;
using UnityEngine;

public class CoreSplitter : MonoBehaviour
{
    [SerializeField]
    private PoolableObject cloneCorePrefab;
    private ObjectPoolingSystem objectPoolingSystem;
    private void Start()
    {
        objectPoolingSystem = ScriptableSystemProvider.Instance.GetSystem<ObjectPoolingSystem>();
    }

    public void Split()
    {
        var cloneCore = objectPoolingSystem.Rent(cloneCorePrefab);
        cloneCore.transform.position = transform.position;
        cloneCore.GetComponent<CoreClone>().Initialize().Forget();
    }
}
