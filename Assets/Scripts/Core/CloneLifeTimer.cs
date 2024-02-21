using AsciiUtil.ScriptableSystem;
using Cysharp.Threading.Tasks;
using UnityEngine;
using AsciiUtil;

public class CoreClone : MonoBehaviour
{
    private CoreInfo coreInfo;
    Rigidbody2D rigidBody;
    private ObjectPoolingSystem objectPoolingSystem;

    private void GetNeededComponents()
    {
        if (rigidBody != null) return;
        coreInfo = InfomationProvider.Instance.CoreInfo;
        objectPoolingSystem = ScriptableSystemProvider.Instance.GetSystem<ObjectPoolingSystem>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    public async UniTaskVoid Initialize()
    {
        GetNeededComponents();

        Vector2 randomVector = Random.insideUnitCircle;
        rigidBody = rigidBody == null ? gameObject.GetComponent<Rigidbody2D>() : rigidBody;
        rigidBody.velocity = randomVector * coreInfo.CloneSpeed;

        await UniTask.WaitForSeconds(coreInfo.ClonellifeTimeSec);
        Destroy(gameObject);
    }
}
