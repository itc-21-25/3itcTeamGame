using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUiController : BaseUiController
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        _GameManager.LevelManager.StartLevel(0);
        _GameManager.UnpauseGame();
        _UiManager.MainMenuUiController.Unload();
        _UiManager.CrossHairUiController.Load();
    }
}
