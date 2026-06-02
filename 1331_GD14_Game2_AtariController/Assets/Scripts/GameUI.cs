using UnityEngine;
using UnityEngine.UI;

//potential way to update the timer and the score
//Can just compile the script for the score/time tracker and the UI updater onto the same script/manager object
public class GameUI : MonoBehaviour
{
    [SerializeField] private Image _timerBarFill;

    //Need to grab from the manager that records the actual timer and score
    //Currently set to default time and score need to replace later
    [SerializeField] private float _timer = 60;
    [SerializeField] private int _score = 99;

    //Temporary max timer field, should be in game manager instead
    [SerializeField] private float _maxTimer = 60;

    //strings created from above timer and score
    private string _scoreText;
    private string _timerText;

    private void Awake()
    {
        //sets timer to max time
        _timer = _maxTimer;

        //turns int and float into string for text
        _scoreText = _timer.ToString();
        _timerText = _timer.ToString();
    }

    private void Update()
    {
        UpdateTimeBar();
    }

    private void UpdateTimeBar()
    {
        //Ticks the timer down (FOR TESTING, REMOVE WHEN REAL THING IMPLEMENTED)
        _timer -= Time.deltaTime;
        
        //in case timer is greater than max timer
        if (_timer > _maxTimer) { _timer = _maxTimer; }
        if (_timer < 0) { _timer = 0; }

        //updates the timer as a 0 to 1 percentage
        _timerBarFill.fillAmount = (_timer / _maxTimer);
    }
}
