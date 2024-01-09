using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan : MonoBehaviour
{
    [SerializeField] private GameObject _SnowManDone = null;
    [SerializeField] private GameObject _SnowManWorkInProgress = null;
    [SerializeField] private float _MinSnowBallScale = 1.5f;
    public float MinSnowBallScale => _MinSnowBallScale;
    [SerializeField] private float _MaxSnowBallScale = 2.5f;
    public float MaxSnowBallScale => _MaxSnowBallScale;

    GameManager _GameManager = null;

    public void Init()
    {
        _SnowManDone.SetActive(false);
        _SnowManWorkInProgress.SetActive(true);
    }

    private void Start()
    {
        _GameManager = GameManager.Get();
        _GameManager.RegisterSnowMan(this);
    }

    public void SetMinScale(float minScale)
    {
        _MinSnowBallScale = minScale;
    }

    public void SetMaxScale(float maxScale)
    {
        _MaxSnowBallScale = maxScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SnowBall snowBall = null;

        if (collision.transform.TryGetComponent(out snowBall))
        {
            if (snowBall.Scale.x >= _MinSnowBallScale && snowBall.Scale.x <= _MaxSnowBallScale)
            {
                Destroy(snowBall.gameObject);
                _SnowManDone.SetActive(true);
                _SnowManWorkInProgress.SetActive(false);

                _GameManager.PauseGame();
                _GameManager.UiManager.CrossHairUiController.Unload();
                _GameManager.UiManager.LevelWinUiController.Load();
                _GameManager.LevelManager.EndLevel();
            }
        }
    }

    private void OnDestroy()
    {
        _GameManager.UnregisterSnowMan();
    }
}
