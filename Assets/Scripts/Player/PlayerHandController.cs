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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _RaycastRadius))
            {
                SnowBall snowBall = null;

                if (hit.transform.gameObject.TryGetComponent(out snowBall))
                {
                    Vector3 hitDirection = hit.point - transform.position;
                    Rigidbody snowBallRb = snowBall.GetComponent<Rigidbody>();
                    snowBallRb.AddForce(hitDirection.normalized * _ImpulseForce, ForceMode.Impulse);
                }
            }
        }
    }
}
