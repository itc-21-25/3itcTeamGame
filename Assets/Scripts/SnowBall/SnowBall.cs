using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] private float _BaseScale = 0.5f;
    [SerializeField] private float _BaseMass = 0.5f;
    [SerializeField] private float _IncreaseScale = 0.1f;
    [SerializeField] private float _IncreaseMass = 0.05f;
    [SerializeField] private Material _Skin;

    private Rigidbody _MyRigibody = null;
    public Rigidbody MyRigibody => _MyRigibody;

    private GameManager _GameManager = null;

    public Vector3 Scale => transform.localScale;

    public void Init()
    {
        _MyRigibody = GetComponent<Rigidbody>();
        transform.localScale = new Vector3(_BaseScale, _BaseScale, _BaseScale);
        _MyRigibody.mass = _BaseMass;
    }

    private void Start()
    {
        _GameManager = GameManager.Get();
        _GameManager.RegisterSnowBall(this);
    }

    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    public void SetMass(float mass)
    {
        _MyRigibody.mass = mass;
    }

    public void UpdateSnowBall()
    {
        if (!_MyRigibody.IsSleeping())
        {
            float speed = _MyRigibody.velocity.magnitude;

            if (speed >= 1f)
            {
                float newMass = _IncreaseMass * speed * Time.deltaTime;
                float newScale = _IncreaseScale * speed * Time.deltaTime;
                newScale = transform.localScale.x + newScale;

                transform.localScale = new Vector3(newScale, newScale, newScale);
                _MyRigibody.mass = _MyRigibody.mass + newMass;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fence" || collision.gameObject.tag == "SnowMan")
        {
            Vector3 surfaceNormal = collision.contacts[0].normal;
            Vector3 impactDirection = -collision.relativeVelocity.normalized;
            Vector3 reflectionDirection = Vector3.Reflect(impactDirection, surfaceNormal);

            float speed = collision.relativeVelocity.magnitude;
            Vector3 newVelocity = reflectionDirection * speed;

            _MyRigibody.velocity = newVelocity;
        }
    }

    private void OnDestroy()
    {
        _GameManager.UnregisterSnowBall();
    }
}
