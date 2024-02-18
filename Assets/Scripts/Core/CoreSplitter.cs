using AsciiUtil;
using AsciiUtil.ScriptableSystem;
using UnityEngine;

public class CoreSplitter : MonoBehaviour
{
    [SerializeField]
    private PoolableObject cloneCorePrefab;
    [SerializeField]
    private CoreSpeedController coreSpeedController;
    private ObjectPoolingSystem objectPoolingSystem;
    private void Start()
    {
        objectPoolingSystem = ScriptableSystemProvider.Instance.GetSystem<ObjectPoolingSystem>();
    }

    public void Split(int splitCount)
    {
        if (!coreSpeedController.IsFever)
        {
            SplitCore();
            return;
        }
        for (int i = 0; i < splitCount; i++)
        {
            SplitCore();
        }
    }

    private void SplitCore()
    {
        var cloneCore = objectPoolingSystem.Rent(cloneCorePrefab);
        cloneCore.transform.position = transform.position;
        cloneCore.GetComponent<CoreClone>().Initialize().Forget();
    }
}
