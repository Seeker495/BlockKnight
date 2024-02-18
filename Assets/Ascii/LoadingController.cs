using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private float fakeLoadingTime = 4.0f;
    [SerializeField]
    private Image loadingCircleFill;
    private FloatReactiveProperty currentElapcedTime = new FloatReactiveProperty(0.0f);

    private void Start()
    {
        currentElapcedTime.Subscribe(current =>
        {
            loadingCircleFill.fillAmount = current / fakeLoadingTime;
            if (current >= fakeLoadingTime)
            {
                //シーン読み込み
                SceneManager.LoadScene(nextSceneName);
            }
        });
    }

    private void Update()
    {
        currentElapcedTime.Value += Time.deltaTime;
    }
}
