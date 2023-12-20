using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] private int levelId = 0;
    [SerializeField] private int maxLevelId = SceneManager.sceneCount - 1;
    
    
    public void StartLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void NextLevel()
    {
        if (levelId < maxLevelId)
        {
            StartLevel(levelId + 1);
        }
    }
    public void PreviousLevel() 
    {
        if (levelId > 0)
        {
            StartLevel(levelId - 1);
        }
    }
    public void EndLevel()
    {
        SceneManager.LoadScene("menu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void UpdateLevel()
    {
        RestartLevel();
    }
}