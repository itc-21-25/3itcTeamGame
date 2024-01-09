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

    private float _XAngle = 0f;

    public void Init()
    {
        _GameManager = GameManager.Get();
        _CameraTrans = _GameManager.PlayerManager.MainCamera.transform;
    }

    public void UpdateMove()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Vector3 newPosition = transform.localPosition;
            float speed = _WalkSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * speed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * speed;
            }

            
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * speed;
            }
        }

        float rotationY = Input.GetAxis("Mouse X") * _MouseSensitive;
        float rotationX = Input.GetAxis("Mouse Y") * _MouseSensitive;

        _XAngle -= rotationX;
        _XAngle = Mathf.Clamp(_XAngle, -_MaxXAngle, _MaxXAngle);

        Vector3 rotation = _CameraTrans.localRotation.eulerAngles;
        rotation.x = _XAngle;
        _CameraTrans.localRotation = Quaternion.Euler(rotation);

        // rotuj objekt kolem osy Y
        transform.Rotate(0f, rotationY, 0f);
    }
}
