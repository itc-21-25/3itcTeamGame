using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float _WalkSpeed = 2.5f;
    [SerializeField] private float _MouseSensitive = 100f;
    [SerializeField] private float _MaxXAngle = 60f;

    private Transform _CameraTrans = null;
    private GameManager _GameManager = null;
    Rigidbody _rb = null;
    PlayerManager _PlayerManager = null;

    private float _XAngle = 0f;

    public void Init()
    {
        _GameManager = GameManager.Get();
        _PlayerManager = PlayerManager.Get();
        _CameraTrans = _GameManager.PlayerManager.MainCamera.transform;
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    public void UpdateMove()
    {
        Vector3 moveVec = new Vector3( Input.GetAxis("Horizontal") * _WalkSpeed, 0, Input.GetAxis("Vertical") * _WalkSpeed);

        _rb.velocity = moveVec;
    }
}
