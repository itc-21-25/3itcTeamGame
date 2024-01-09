using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWinUiController : BaseUiController
{
    [SerializeField] private GameObject _NextLevelText = null;
    [SerializeField] private GameObject _GameFinishText = null;
    [SerializeField] private GameObject _NextLevelButton = null;

    public void NextLevel()
    {
        _GameManager.LevelManager.NextLevel();
        _GameManager.UnpauseGame();
        _UiManager.LevelWinUiController.Unload();
        _UiManager.CrossHairUiController.Load();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public override void Load()
    {
        base.Load();

        if (_GameManager.LevelManager.IsNextLevelExist())
        {
            _NextLevelText.SetActive(true);
            _GameFinishText.SetActive(false);
            _NextLevelText.SetActive(true);
        }
        else
        {
            _NextLevelText.SetActive(false);
            _GameFinishText.SetActive(true);
            _NextLevelText.SetActive(false);
        }
    }
}
