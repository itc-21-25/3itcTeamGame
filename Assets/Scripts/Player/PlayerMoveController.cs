using Cinemachine;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float _WalkSpeed = 2.5f;
    [SerializeField] private float _MouseSensitive = 100f;
    [SerializeField] private float _MaxXAngle = 60f;

    Rigidbody _rb = null;
    PlayerManager _PlayerManager = null;

    public void Init()
    {
        _PlayerManager = gameObject.GetComponent<PlayerManager>();
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    public void UpdateMove()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal") * (_WalkSpeed + _PlayerManager.PlayerStats.Beyblade.GetTotalStat("Speed")), _rb.velocity.y, Input.GetAxis("Vertical") * (_WalkSpeed + _PlayerManager.PlayerStats.Beyblade.GetTotalStat("Speed"))).normalized;
        float xRot = Input.GetAxis("Mouse X");
        transform.Rotate(0, xRot*_MouseSensitive, 0);
        _rb.velocity = moveVec * transform.forward;
    }
}
