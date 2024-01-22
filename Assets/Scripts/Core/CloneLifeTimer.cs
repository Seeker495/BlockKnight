using AsciiUtil.ScriptableSystem;
using Cysharp.Threading.Tasks;
using UnityEngine;
using AsciiUtil;
using Unity.VisualScripting;

public class CoreClone : MonoBehaviour
{
    [SerializeField]
    private CoreInfo coreInfo;
    Rigidbody2D rigidBody;
    private ObjectPoolingSystem objectPoolingSystem;
    private void Start()
    {
        objectPoolingSystem = ScriptableSystemProvider.Instance.GetSystem<ObjectPoolingSystem>();
    }

    public async UniTaskVoid Initialize()
    {
        Vector2 randomVector = Random.insideUnitCircle;
        rigidBody = rigidBody == null ? gameObject.GetComponent<Rigidbody2D>() : rigidBody;
        rigidBody.velocity = randomVector * coreInfo.CloneSpeed;

        await UniTask.WaitForSeconds(coreInfo.ClonellifeTimeSec);
        objectPoolingSystem.Release(gameObject.GetComponent<PoolableObject>());
    }
}
