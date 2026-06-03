using Unity.VisualScripting;
using UnityEngine;

//This should manage the score and the timer for ther game
//Can expand to include more features if there's time
public class GameManager : Singleton<GameManager>
{
    [SerializeField] public float _timer;
    [SerializeField] public float _maxTimer = 60.0f;

    [SerializeField] public int _score = 0;

    //checks if timer should be on or not
    [SerializeField] private bool _timerActive = false;
    //game UI prefab
    [SerializeField] private GameUI _gameUI;


    private void Start()
    {
        //Spawns game UI from prefab
        Instantiate(_gameUI);

        //Start immediately on spawn, can change to different things (on button press, on reset game, etc.)
        StartGameTimerFromMax();
    }

    private void Update()
    {
        if (_timerActive)
        {
            Timer();
        }
    }

    private void Timer()
    {
        //in case timer is greater than max timer
        if (_timer > _maxTimer) { _timer = _maxTimer; }
        if (_timer < 0f) { _timer = 0f; }

        //lowers timer over time
        _timer -= Time.deltaTime;

        if (_timer <= 0f )
        {
            GameComplete();
        }
    }    

    public void StartGameTimerFromMax()
    {
        //sets timer to max timer
        _timer = _maxTimer;

        //starts timer
        _timerActive = true;
    }

    private void GameComplete()
    {
        //stops timer
        _timerActive = false;
    }
}
