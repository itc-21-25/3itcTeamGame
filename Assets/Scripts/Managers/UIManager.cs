using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IManager
{
    static UIManager _instance;

    List<BaseUIController> controllers = new List<BaseUIController>();

    public static UIManager Instance => _instance;
    private void Awake()
    {
        
    }

    public void Stop()
    {
        //TODO: Implement
        throw new System.NotImplementedException();
    }
    void IManager.Start()
    {
        if (_instance == null)
        {
            _instance = this;
            GameManager.Instance.AddManager(Instance);
        }
        Debug.Log("Test");
    }
    public void AddController(BaseUIController controller)
    {
        controllers.Add(controller);
    }

    void HideAllUI()
    {
        for (int i = 0; i < controllers.Count; i++)
        {
            controllers[i].HideUI();
        }
    }
}