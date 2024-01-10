using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<LevelController> _LevelControllers = new List<LevelController>();
    [SerializeField] private int _ActualLevel = 0;

    public void Init()
    {

    }

    public void RestartLevel()
    {
        StartLevel(_ActualLevel);
    }

    public bool IsNextLevelExist()
    {
        if (_ActualLevel == _LevelControllers.Count)
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
}
