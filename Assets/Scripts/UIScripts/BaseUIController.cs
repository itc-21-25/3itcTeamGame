using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUIController : MonoBehaviour
{
    [SerializeField] protected Canvas _uiRoot;
    protected virtual void AddToManager()
    {
        UIManager.Instance.AddController(this);
    }
    public abstract void HideUI();
    public abstract void ShowUI();
    public abstract void UpdateUI();
}
