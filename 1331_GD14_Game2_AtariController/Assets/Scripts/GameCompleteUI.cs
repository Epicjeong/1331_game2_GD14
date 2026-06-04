using TMPro;
using UnityEngine;

public class GameCompleteUI : MonoBehaviour
{
    //TMP Components
    [SerializeField] private TextMeshProUGUI _scoreCurrentText;
    [SerializeField] private TextMeshProUGUI _scoreHighText;

    private int _scoreCurrent;
    private int _scoreHigh;

    private void OnEnable()
    {
        _scoreCurrent = GameManager.Instance._score;
        _scoreHigh = GameManager.Instance._highScore;

        _scoreCurrentText.text = _scoreCurrent.ToString();
        _scoreHighText.text = _scoreHigh.ToString();
    }
}
