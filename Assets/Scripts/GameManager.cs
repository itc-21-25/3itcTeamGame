using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance = null;

    [SerializeField] private PlayerManager _PlayerManager = null;
    public PlayerManager PlayerManager => _PlayerManager;

    [SerializeField] private SnowBall _SnowBall = null;
    public SnowBall SnowBall => _SnowBall;

    [SerializeField] private SnowMan _SnowMan = null;
    public SnowMan SnowMan => _SnowMan;

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

        PauseGame();
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            _PlayerManager.UpdatePlayer();
            _LevelManager.UpdateLevel();
            _UiManager.UpdateUi();

            if (_SnowBall != null)
            {
                _SnowBall.UpdateSnowBall();
            }
        }
    }

    public void RegisterSnowBall(SnowBall snowBall)
    {
        _SnowBall = snowBall;
        snowBall.Init();
    }

    public void UnregisterSnowBall()
    {
        _SnowBall = null;
    }

    public void UnregisterSnowMan()
    {
        _SnowMan = null;
    }

    public void RegisterSnowMan(SnowMan snowMan)
    {
        _SnowMan = snowMan;
        snowMan.Init();
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

    private void LateUpdate()
    {
    }
}
