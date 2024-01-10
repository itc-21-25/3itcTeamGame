using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMoveController _PlayerMoveController = null;
    public PlayerMoveController PlayerMoveController => _PlayerMoveController;

    [SerializeField] private PlayerHandController _PlayerHandController = null;
    public PlayerHandController PlayerHandController => _PlayerHandController;

    [SerializeField] private Camera _MainCamera = null;
    public Camera MainCamera => _MainCamera;

    [SerializeField] private PlayerAudioManager _PlayerAudioManager = null;
    public PlayerAudioManager PlayerAudioManager => _PlayerAudioManager;

    [SerializeField] private PlayerCashManager _PlayerCashManager = null;
    public PlayerCashManager PlayerCashManager => _PlayerCashManager;

    //[SerializeField] private ShopManager _ShopManager = null;
    //public ShopManager ShopManager => _ShopManager;

    [SerializeField] PlayerStats _PlayerStats = null;
    public PlayerStats PlayerStats => _PlayerStats;

    public void Init()
    {  
        _PlayerMoveController.Init();
        _PlayerHandController.Init();
    }

    public void UpdatePlayer()
    {
        _PlayerMoveController.UpdateMove();
        _PlayerHandController.UpdateHand();
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
