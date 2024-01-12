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

    [SerializeField] private List<GameObject> _TopParts = null;
    public List<GameObject> TopParts => _TopParts;

    [SerializeField] private List<GameObject> _MidParts = null;
    public List<GameObject> MidParts => _MidParts;

    [SerializeField] private List<GameObject> _BottomParts = null;
    public List<GameObject> BottomParts => _BottomParts;

    public Camera NIGGACAM;
    public Camera NIGGAUIKUKNAKAMERU;
    public GameObject canvasNiggaHolder;
    
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
    private void FixedUpdate()
    {
        if (canvasNiggaHolder.gameObject.activeInHierarchy) { 
            NIGGAUIKUKNAKAMERU.gameObject.SetActive(true); 
            NIGGACAM.gameObject.SetActive(false);
        }
        else { 
            NIGGACAM.gameObject.SetActive(true);
            NIGGAUIKUKNAKAMERU.gameObject.SetActive(false) ;
        }
    }
    public void Init()
    {
        _PlayerManager.Init();
        _LevelManager.Init();
        _UiManager.Init();
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
    public List<GameObject> CreateBeybladeBuild()
    {
        List<GameObject> selectedParts = new List<GameObject>();
        selectedParts.Add(_TopParts[Random.Range(0,_TopParts.Count)]);
        selectedParts.Add(_MidParts[Random.Range(0, _MidParts.Count)]);
        selectedParts.Add(_BottomParts[Random.Range(0, _BottomParts.Count)]);
        return selectedParts;
    }
}