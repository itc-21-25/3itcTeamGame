using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUIController
{
    [SerializeField] protected Canvas _uiRoot;
    public abstract void HideUI();
    public abstract void ShowUI();
    public abstract void UpdateUI();
}
