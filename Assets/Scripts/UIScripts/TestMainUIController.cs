using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestMainUIController : BaseUIController
{
    [SerializeField] GameObject _otherUI;
    private void Awake()
    {
        AddToManager();
    }
    public override void HideUI()
    {
        _uiRoot.SetActive(false);
    }

    public override void ShowUI()
    {
        _uiRoot.SetActive(true);
    }

    public override void UpdateUI()
    {
        Debug.Log("Nothing to update in LevelUI");
    }
    public void LoadLevel(string levelName)
    {
        //TODO: Make GameManager load the desired scene
    }
    public void Quit()
    {
        GameManager.Instance.QuitApp();
    }
    public void ShowOtherUI()
    {
        _otherUI.SetActive(true);
    }
}
