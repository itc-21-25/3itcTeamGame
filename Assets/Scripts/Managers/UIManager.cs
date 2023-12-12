using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, IManager
{
    static UIManager _instance;

    List<BaseUIController> controllers = new List<BaseUIController>();

    [field: SerializeField] List<Scene> Levels = new();

    private List<string> _levelNames = new();
    private GameState _gameState;


    public static UIManager Instance => _instance;
    public GameState GameState => _gameState;
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            GameManager.Instance.AddManager(Instance);
        }
        FillLevelNamesList();
    }

    private void FillLevelNamesList()
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            _levelNames.Add(Levels[i].name);
        }
    }
    public void Stop()
    {
        //TODO: Implement
        _gameState = GameState.Stopped;
        throw new System.NotImplementedException();
    }
    void IManager.Start()
    {
        //TODO: Implement
        _gameState = GameState.Playing;
        throw new System.NotImplementedException();
    }
    public void AddController(BaseUIController controller)
    {
        controllers.Add(controller);
    }

    void HideAllUI()
    {
        for (int i = 0; i < controllers.Count; i++)
        {
            controllers[i].HideUI();
        }
    }
}

public enum GameState
{
    Playing,
    Stopped,
    Paused,
}