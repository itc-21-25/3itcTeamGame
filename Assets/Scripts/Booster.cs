using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private float _SpeedUp = 2f;
    [SerializeField] private float _SnowBallMinimalizer = 0.5f;
    [SerializeField] private int BoosterCoinsAdd;

    private void OnCollisionEnter(Collision collision)
    {
        /*
        SnowBall snowBall = null;
        PlayerCashManager playerCashManager = FindObjectOfType<PlayerCashManager>(); // pøístup k cash manageru

        if (collision.transform.TryGetComponent(out snowBall))
        {
            playerCashManager.AddCoins(BoosterCoinsAdd);
            snowBall.SetScale(snowBall.Scale.x * _SnowBallMinimalizer);
            snowBall.SetMass(snowBall.MyRigibody.mass * _SnowBallMinimalizer);

            GameManager.Get().PlayerManager.PlayerHandController.SetImpulseForce(GameManager.Get().PlayerManager.PlayerHandController.ImpulseForce + _SpeedUp);

            Destroy(gameObject);
        }
        */
    }
}
