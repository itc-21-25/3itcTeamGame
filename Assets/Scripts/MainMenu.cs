using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject setttingsMenu;
    public void ChangeToMainMenu()
    {
        mainMenu.SetActive(true);
        setttingsMenu.SetActive(false);
    }
    public void ChangeToSettingsMenu()
    {
        mainMenu.SetActive(false);
        setttingsMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }


}
