using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IManager
{
    static UIManager _instance;
    public static UIManager Instance => _instance;

    List<UIController> controllers = new List<UIController>();
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            GameManager.Instance.AddManager(Instance);
        }
    }
    public void Stop()
    {
        //TODO: Implement
        throw new System.NotImplementedException();
    }
    void IManager.Start()
    {
        //TODO: Implement
        throw new System.NotImplementedException();
    }
    public void AddController(UIController controller)
    {
        controllers.Add(controller);
    }
    void HideUI()
    {
        for (int i = 0; i < controllers.Count; i++)
        {
            controllers[i].HideUI();
        }
    }
}
