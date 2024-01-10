using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    [SerializeField] private float _RaycastRadius = 2f;
    [SerializeField] private float _ImpulseForce = 10f;
    [SerializeField] private float _DefaultImpulseForce = 10f;

    public float ImpulseForce => _ImpulseForce;

    private GameManager _GameManager = null;
    private Camera _MainCamera = null;

    public void Init()
    {
        _GameManager = GameManager.Get();
        _MainCamera = _GameManager.PlayerManager.MainCamera;
    }

    public void SetDefaultImpulseForce()
    {
        _ImpulseForce = _DefaultImpulseForce;
    }

    public void SetImpulseForce(float force)
    {
        _ImpulseForce = force;
    }

    public void UpdateHand()
    {

    }
}
