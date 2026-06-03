using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

//This should track the score and the timer for the game at the minimum
public class GameManager : Singleton<GameManager>
{
<<<<<<< HEAD

    //note to yi: if the variables public it doesnt need to be serialized
    public float _timer;
    public float _maxTimer = 60.0f;

    public int _score = 0;

    //checks if timer should be on or not
=======
    public float _timer {  get; private set; }
    public float _maxTimer;
    public int _score {  get; private set; }
    public int _highScore { get; private set; }

>>>>>>> b79b7186f5beae56fd6ab777475bb74e884de653
    [SerializeField] private bool _timerActive = false;

    //UI prefabs
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _startMenuUI;

    //Why did i do this
    [SerializeField] private PlayerControl _player;
    private PlayerInput _playerInput;

    private void Start()
    {
        _startMenuUI.SetActive(true);

        //Get inputs
        _playerInput = _player.GetComponent<PlayerInput>();

        //Changes input map to "menu"
        _playerInput.actions.FindActionMap("Menu").Enable();
        _playerInput.actions.FindActionMap("Player").Disable();
    }

    private void Update()
    {
        if (_timerActive)
        {
            Timer();
        }
    }

    //No idea why I did this here, im fucking tired
    public void MenuButton(InputAction.CallbackContext context)
    {
        _startMenuUI.SetActive(false);

        BeginPlay();
    }

    private void Timer()
    {
        //in case timer is greater than max timer, or lower than 0
        if (_timer > _maxTimer) { _timer = _maxTimer; }
        if (_timer < 0f) { _timer = 0f; }

        _timer -= Time.deltaTime;

        if (_timer <= 0f )
        {
            GameComplete();
        }
    }    

    public void BeginPlay()
    {
        //resets score;
        _score = 0;

        //sets timer to max timer
        _timer = _maxTimer;

        //Shows game UI
        _gameUI.SetActive(true);

        //Changes input map to "Player"
        _playerInput.actions.FindActionMap("Menu").Disable();
        _playerInput.actions.FindActionMap("Player").Enable();

        //starts timer
        _timerActive = true;
    }

    private void GameComplete()
    {
        //stops timer
        _timerActive = false;

        //Hides game UI
        _gameUI.SetActive(false);

        //sets a high score
        if (_score >= _highScore) { _highScore = _score; }

        //Changes input map to "menu"
        _playerInput.actions.FindActionMap("Menu").Enable();
        _playerInput.actions.FindActionMap("Player").Disable();

        //Need logic below to display "Play Again Screen"
    }

    public void ScoreAdd()
    {
        _score++;
    }
}
