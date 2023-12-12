using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    List<IManager> managers = new List<IManager>();
    [field: SerializeField] List<Scene> Levels = new();

    private List<string> _levelNames = new();
    private GameState _gameState = GameState.Stopped;

    public static GameManager Instance => _instance;
    public GameState GameState => _gameState;
    public Action OnStateChange;

    private void Awake()
    {
        if(_instance == null)
            _instance = this;
    }
    public void Pause(bool pauseGame)
    {
        if(pauseGame)
        {
            _gameState = GameState.Paused;
            Time.timeScale = 0.0f;
        }
        else
        {
            _gameState = GameState.Playing;
            Time.timeScale = 1.0f;
        }
        OnStateChange?.Invoke();
    }
    public void Stop()
    {
        for (int i = 0; i < managers.Count; i++)
            managers[i].Stop();

        _gameState = GameState.Stopped;
        OnStateChange?.Invoke();

        Time.timeScale = 0.0f;
    }
    public void Start()
    {
        for (int i = 0; i < managers.Count; i++)
            managers[i].Start();

        FillLevelNamesList();

        Time.timeScale = 1.0f;

        _gameState = GameState.Playing;
        OnStateChange?.Invoke();
    }
    public void AddManager(IManager manager)
    {
        managers.Add(manager);
    }

    private void FillLevelNamesList()
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            _levelNames.Add(Levels[i].name);
        }
    }
}

public enum GameState
{
    Playing,
    Stopped,
    Paused,
}