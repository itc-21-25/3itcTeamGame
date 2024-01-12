using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<LevelController> _LevelControllers = new List<LevelController>();
    [SerializeField] private int _ActualLevel = 0;
    private static LevelManager _instance;
    public static LevelManager Instance => _instance;
    public int ActualLevelID => _ActualLevel;   
    public IReadOnlyCollection<LevelController> LevelControllers => _LevelControllers;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
    public void Init()
    {

    }

    public void RestartLevel()
    {
        StartLevel(_ActualLevel);
    }

    public bool IsNextLevelExist()
    {
        if (_ActualLevel >= _LevelControllers.Count-1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void EndLevel()
    {
        _LevelControllers[_ActualLevel].EndLevel();
    }

    public void NextLevel()
    {
        StartLevel(_ActualLevel + 1);
    }

    public void PrevLevel()
    {

    }
    public void StartLevel(int levelId)
    {
        _ActualLevel = levelId;

        _LevelControllers[_ActualLevel].Init();
        _LevelControllers[_ActualLevel].StartLevel();
    }
    public void ResetRun()
    {
        SceneManager.LoadScene("PETR P");
    }
}