using TMPro;
using UnityEngine;
using UnityEngine.UI;

//potential way to update the timer and the score
//Can just compile the script for the score/time tracker and the UI updater onto the same script/manager object
public class GameUI : MonoBehaviour
{
    //Bar for the timer
    [SerializeField] private Image _timerBarFill;
    //Number for the timer
    [SerializeField] private TextMeshProUGUI _timerNumberText;
    //Number for the score
    [SerializeField] private TextMeshProUGUI _scoreNumberText;

    //strings created from timer and score
    private string _scoreString;
    private string _timerString;

    private void Update()
    {    
        UpdateTime();
    }

    public void UpdateTime()
    {
        //turns int/float into string for text
        _timerString = GameManager.Instance._timer.ToString("F1");

        //updates the timer bar (timer/maxtimer = percentage of time left = fill amount)
        _timerBarFill.fillAmount = (GameManager.Instance._timer / GameManager.Instance._maxTimer);
        //updates the timer text (shown number on UI)
        _timerNumberText.text = _timerString;
    }

    public void UpdateScoreNumber()
    {
        //turns int and float into string for text
        _scoreString = GameManager.Instance._score.ToString();

        _scoreNumberText.text = _timerString;
    }
}
