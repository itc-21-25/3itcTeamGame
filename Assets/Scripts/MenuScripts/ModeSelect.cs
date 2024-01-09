using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModeSelect : MonoBehaviour
{
    int selectedIndex = 0;
    LevelManager levelManager;
    public void Play()
    {
        levelManager.EndLevel();
    }
    public void Deathmatch()
    {
        selectedIndex = 0;
        //bayblade
        Ok();
    }
    public void LastManStanding()
    {
        selectedIndex = 1;
        //bayblade
        Ok();
    }

    void Ok()
    {
        if (selectedIndex == 0)
        {
            levelManager.StartLevel(5);
        }
        else if (selectedIndex == 1)
        {
            levelManager.StartLevel(6);
        }
    }
}
