using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerSpawn = null;

    private LevelManager _LevelManager = null;
    private GameManager _GameManager = null;
    private PlayerManager _PlayerManager = null;

    private List<GameObject> _MyGameobjects = new List<GameObject>();
    private List<Transform> _SpawnPositions = new List<Transform>();

    private bool _LevelStart = false;

    public void Init()
    {
        _GameManager = GameManager.Get();
        _LevelManager = _GameManager.LevelManager;
        _PlayerManager = _GameManager.PlayerManager;
        gameObject.SetActive(true);
    }

    public void Kill()
    {
       
        _GameManager.PlayerManager.PlayerAudioManager.PlayDeadAudio();
            _GameManager.UiManager.CrossHairUiController.Unload();
            _GameManager.UiManager.GameOverUi.Load();
            _GameManager.PauseGame();
            EndLevel();
    }

    public void StartLevel()
    {
        for (int i = 0; i < _MyGameobjects.Count; i++)
            Instantiate(_MyGameobjects[i].gameObject, _SpawnPositions[i].position, Quaternion.identity);

        _PlayerManager.SetPosition(_PlayerSpawn.transform.position);
        _LevelStart = true;
    }

    public void KilledEnemy(GameObject enemy)
    {
        if (_MyGameobjects.Contains(enemy))
            _MyGameobjects.Remove(enemy);

        if (_MyGameobjects.Count <= 0)
            EndLevel();
    }
    public void EndLevel()
    {
        _LevelStart = false;
        Debug.Log($"Finished level!");
        for (int i = 0; i < _MyGameobjects.Count; i++)
        {
            Destroy(_MyGameobjects[i]);
        }

        gameObject.SetActive(false);
    }
}