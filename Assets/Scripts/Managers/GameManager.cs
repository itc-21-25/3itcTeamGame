using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;
    List<IManager> managers = new List<IManager>();
    private void Awake()
    {
        if(_instance == null)
            _instance = this;
    }
    public void Pause(bool pauseGame)
    {
        if(pauseGame)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }
    public void Stop()
    {
        for (int i = 0; i < managers.Count; i++)
            managers[i].Stop();

        Time.timeScale = 0.0f;
    }
    public void Start()
    {
        for (int i = 0; i < managers.Count; i++)
            managers[i].Start();

        Time.timeScale = 1.0f;
    }
    public void AddManager(IManager manager)
    {
        managers.Add(manager);
    }
}
