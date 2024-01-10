using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance = null;

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

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    public static PlayerManager Get()
    {
        return _instance;
    }

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
