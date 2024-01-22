using Cysharp.Threading.Tasks;
using UnityEngine;

public class CloneLifeTimer : MonoBehaviour
{
    [SerializeField]
    private float lifeTimeSec;

    async void Start()
    {
        await UniTask.WaitForSeconds(lifeTimeSec);
        Destroy(gameObject);
    }
}
