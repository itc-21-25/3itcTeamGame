using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float _RotationSpeed = 10f;
    [SerializeField] private float _RotationTime = 2f;
    [SerializeField] private AudioSource _AudioSource = null;
    [SerializeField] private AudioClip _AudioClip = null;
    [SerializeField] private int TreeCoinsReduce;

    private bool _Rotate = false;

    private void OnCollisionEnter(Collision collision)
    {
        /*
        SnowBall snowBall = null;
        PlayerCashManager playerCashManager = FindObjectOfType<PlayerCashManager>(); // vytvoøení instance tøídy

        if (collision.transform.TryGetComponent(out snowBall))
        {
            StartCoroutine(Animation());
            playerCashManager.ReduceCoins(TreeCoinsReduce);
        }
        */
    }

    private IEnumerator Animation()
    {
        if (!_AudioSource.isPlaying)
        {
            _AudioSource.clip = _AudioClip;
            _AudioSource.Play();
        }

        float rotationTime = 0f;

        while (true)
        {
            rotationTime = rotationTime + Time.deltaTime;

            transform.Rotate(0, _RotationSpeed * Time.deltaTime, 0);

            if (rotationTime >= _RotationTime)
            {
                break;
            }

            yield return null;
        }

        yield return null;
    }
}
