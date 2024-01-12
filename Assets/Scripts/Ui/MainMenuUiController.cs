using UnityEngine;

public class MainMenuUiController : BaseUiController
{
    [field: SerializeField] Canvas _SelectBeybladeScreen;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        _UiManager.MainMenuUiController.Unload();
        _GameManager.LevelManager.StartLevel(0);
        _GameManager.UnpauseGame();
        Debug.Log("new game click");
    }
    public void SelectBeyblade()
    {
        if (!_SelectBeybladeScreen.enabled)
            _SelectBeybladeScreen.enabled = true;
    }
    public void Exit()
    {
#if UNITY_EDITOR

#endif
        Application.Quit(420);
    }
}
