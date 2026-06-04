using UnityEngine;
using UnityEngine.UI;

public class StartMenuUIScript : MonoBehaviour
{
    [Header("Volume: 0 - 1")]
    [SerializeField] private float _volume = 1;

    [SerializeField] private Button _button;

    private void OnEnable()
    {
        AudioMgr.Instance.PlayMusic(AudioMgr.MusicType.Menu, _volume);
        _button.onClick.AddListener(GameManager.Instance.BeginPlay);
    }

    private void OnDisable()
    {
        AudioMgr.Instance.StopMusic();
        _button.onClick.RemoveAllListeners();
        Destroy(gameObject);
    }
}
