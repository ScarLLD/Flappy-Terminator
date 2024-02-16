using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _enemyGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _enemyBulletPool;
    [SerializeField] private BulletPool _playerBulletPool;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _player.Dead += OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _player.SwitchInputStatus();
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _player.Dead -= OnGameOver;
    }
    
    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
        _player.SwitchInputStatus();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.SwitchInputStatus();
        _player.Reset();
        _enemyPool.Reset();
        _enemyBulletPool.Reset();
        _playerBulletPool.Reset();
    }
}