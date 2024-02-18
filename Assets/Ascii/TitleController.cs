using UnityEngine;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    private string titleBGMKey = "Title";
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayBGM(titleBGMKey);
    }
}
