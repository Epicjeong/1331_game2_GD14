using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartMenuUIScript : MonoBehaviour
{
    [Header("Volume: 0 - 1")]
    [SerializeField] private float _volume = 1;

    [SerializeField] private Button _button;

    private void OnEnable()
    {
        AudioMgr.Instance.PlayMusic(AudioMgr.MusicType.Start, _volume);
        _button.onClick.AddListener(GameManager.Instance.BeginPlay);
    }

    private void Update()
    {
        EventSystem.current.SetSelectedGameObject(_button.gameObject);
    }

    private void OnDisable()
    {
        AudioMgr.Instance.StopMusic();
        _button.onClick.RemoveAllListeners();
        Destroy(gameObject);
    }
}
