using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUi : BaseUiController
{
    public void RestartLevel()
    {
        _GameManager.LevelManager.RestartLevel();
        _UiManager.GameOverUi.Unload();
        _UiManager.CrossHairUiController.Load();
        _GameManager.UnpauseGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
