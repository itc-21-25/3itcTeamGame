using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMoveController _PlayerMoveController = null;
    public PlayerMoveController PlayerMoveController => _PlayerMoveController;

    [SerializeField] private Camera _MainCamera = null;
    public Camera MainCamera => _MainCamera;

    [SerializeField] private PlayerAudioManager _PlayerAudioManager = null;
    public PlayerAudioManager PlayerAudioManager => _PlayerAudioManager;

    [SerializeField] PlayerStats _PlayerStats = null;
    public PlayerStats PlayerStats => _PlayerStats;

    [field: SerializeField] Transform ComponentParent;

    public void Init()
    {  
        _PlayerMoveController.Init();

        for (int i = 0; i < ComponentParent.childCount; i++)
            Destroy(ComponentParent.GetChild(0).gameObject);

        // Null check, so the code can be tested before we have the components done
        //TODO: Remove null check, when not needed anymore
        if (_PlayerStats.Beyblade.Top == null || _PlayerStats.Beyblade.Bottom == null || _PlayerStats.Beyblade.Mid == null)
            return;

        Instantiate(_PlayerStats.Beyblade.Top.Prefab, ComponentParent);
        Instantiate(_PlayerStats.Beyblade.Mid.Prefab, ComponentParent);
        Instantiate(_PlayerStats.Beyblade.Bottom.Prefab, ComponentParent);
    }

    public void UpdatePlayer()
    {
        _PlayerMoveController.UpdateMove();
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}