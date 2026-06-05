using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

//This should track the score and the timer for the game at the minimum
public class GameManager : Singleton<GameManager>
{
    //checks if timer should be on or not
    public float _timer {  get; private set; }
    public float _maxTimer;
    public int _score {  get; private set; }
    public int _highScore { get; private set; }
    [SerializeField] private bool _timerActive = false;
    public Camera mainCamera;

    //UI prefabs
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _startMenuUI;
    [SerializeField] private GameObject _completeMenuUI;

    //Why did i do this
    [SerializeField] private PlayerControl _player;
    private PlayerInput _playerInput;

    //Spawn manager to spawn customers when the game starts
    [SerializeField] private SpawnManager _spawnManager;

    private void Start()
    {
        Cursor.visible = false;

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

        //Switches game UI
        if (_startMenuUI) { _startMenuUI.SetActive(false); }
        _completeMenuUI.SetActive(false);
        AudioMgr.Instance.PlaySound(AudioMgr.SoundType.MenuConfirm, 1);
        _gameUI.SetActive(true);

        //Changes input map to "Player"
        _playerInput.actions.FindActionMap("Menu").Disable();
        _playerInput.actions.FindActionMap("Player").Enable();

        //Spawns customers when game begins
        _spawnManager.SpawnCustomer();

        //starts timer
        _timerActive = true;
    }

    private void GameComplete()
    {
        //stops timer
        _timerActive = false;

        //sets a high score (NEEDS TO BE BEFORE UI SWITCH)
        if (_score >= _highScore) { _highScore = _score; }

        //Switches UI
        _gameUI.SetActive(false);

        //Changes input map to "menu"
        _playerInput.actions.FindActionMap("Menu").Enable();
        _playerInput.actions.FindActionMap("Player").Disable();

        //Play Again Screen
        _completeMenuUI.SetActive(true);
    }

    public void ScoreAdd()
    {
        _score++;
    }
}
