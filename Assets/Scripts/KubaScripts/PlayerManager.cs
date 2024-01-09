using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region inicializace controlleru
    [SerializeField]
    private Movement _Movement = null;
    public Movement Movement => _Movement;

    [SerializeField]
    private CashManager _CashManager = null;
    public CashManager CashManager => _CashManager;

    [SerializeField]
    private AudioManager _AudioManager = null;
    public AudioManager AudioManager => _AudioManager;
    #endregion

    public void UpdateMovement()
    {
        _Movement.Update();
    }

    public void ChangeMusicVolume(float volume)
    {
        _AudioManager.ChangeMusicVolume(volume);
    }

    public void ChangeSFXVolume(float volume)
    {
        _AudioManager.ChangeSFXVolume(volume);
    }
}
