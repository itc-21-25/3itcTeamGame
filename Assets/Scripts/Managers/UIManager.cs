using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IManager
{
    private void Awake()
    {
        GameManager.Instance.AddManager(this);
    }
    public void Stop()
    {
        throw new System.NotImplementedException();
    }
    void IManager.Start()
    {
        throw new System.NotImplementedException();
    }
}
