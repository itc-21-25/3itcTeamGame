using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance = null;

    [SerializeField] private PlayerManager _PlayerManager = null;
    public PlayerManager PlayerManager => _PlayerManager;

    [SerializeField] private LevelManager _LevelManager = null;
    public LevelManager LevelManager => _LevelManager;

    [SerializeField] private UiManager _UiManager = null;
    public UiManager UiManager => _UiManager;

    public static GameManager Get()
    {
        return _Instance;
    }

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        else
        {
            Debug.LogError("Chyba!!!");
        }

        Init();
    }

    public void Init()
    {
        _PlayerManager.Init();
        _LevelManager.Init();
        _UiManager.Init();

        //DEBUG
        UnpauseGame();
        _LevelManager.NextLevel();
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            _PlayerManager.UpdatePlayer();
            _UiManager.UpdateUi();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _UiManager.LevelUiController.Unload();
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _UiManager.LevelUiController.Load();
    }
}