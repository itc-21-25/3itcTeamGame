using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IManager
{
    static UIManager _instance;

    List<BaseUIController> _controllers = new List<BaseUIController>();

    public static UIManager Instance => _instance;
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            GameManager.Instance.AddManager(this);
        }
        else
        {
            GameManager.Instance.AddManager(this);
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
    public void AddController(BaseUIController controller)
    {
        _controllers.Add(controller);
    }

    void HideAllUI()
    {
        for (int i = 0; i < _controllers.Count; i++)
        {
            _controllers[i].HideUI();
        }
    }
}