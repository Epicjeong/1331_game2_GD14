using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameCompleteUI : MonoBehaviour
{
    //TMP Components
    [SerializeField] private TextMeshProUGUI _scoreCurrentText;
    [SerializeField] private TextMeshProUGUI _scoreHighText;

    [Header("Volume: 0 - 1")]
    [SerializeField] private float _volume = 1;

    [SerializeField] private Button _button;

    private int _scoreCurrent;
    private int _scoreHigh;

    private void OnEnable()
    {
        AudioMgr.Instance.PlayMusic(AudioMgr.MusicType.Menu, _volume);

        _scoreCurrent = GameManager.Instance._score;
        _scoreHigh = GameManager.Instance._highScore;

        _scoreCurrentText.text = _scoreCurrent.ToString();
        _scoreHighText.text = _scoreHigh.ToString();

        _button.onClick.AddListener(GameManager.Instance.BeginPlay);

        EventSystem.current.SetSelectedGameObject(_button.gameObject);
    }

    private void OnDisable()
    {
        AudioMgr.Instance.StopMusic();
        _button.onClick.RemoveAllListeners();
    }
}
