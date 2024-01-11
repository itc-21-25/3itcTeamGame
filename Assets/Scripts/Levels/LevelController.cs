using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerSpawn = null;

    private LevelManager _LevelManager = null;
    private GameManager _GameManager = null;
    private PlayerManager _PlayerManager = null;

    private List<Enemy> _Enemies = new List<Enemy>();
    private List<Transform> _SpawnPositions = new List<Transform>();

    private bool _LevelStart = false;
    public IReadOnlyCollection<Enemy> Enemies => _Enemies;
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
        for (int i = 0; i < _Enemies.Count; i++)
            Instantiate(_Enemies[i].gameObject, _SpawnPositions[i].position, Quaternion.identity);

        _PlayerManager.SetPosition(_PlayerSpawn.transform.position);
        _LevelStart = true;
    }

    public void KilledEnemy(Enemy enemy)
    {
        if (_Enemies.Contains(enemy))
            _Enemies.Remove(enemy);

        if (_Enemies.Count <= 0)
            EndLevel();
    }
    public void EndLevel()
    {
        _LevelStart = false;
        Debug.Log($"Finished level!");
        for (int i = 0; i < _Enemies.Count; i++)
            Destroy(_Enemies[i]);

        gameObject.SetActive(false);
    }
}