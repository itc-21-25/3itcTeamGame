using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUiController : BaseUiController
{
    [SerializeField] private Text _SnowBallScale = null;
    [SerializeField] private Text _SnowBallMinScale = null;
    [SerializeField] private Text _SnowBallMaxScale = null;
    [SerializeField] private Text _Force = null;
    [SerializeField] private Text _PlayerCash = null;

    public override void UpdateUiCanvas()
    {
        if (_MyCanvas.enabled && _GameManager.SnowBall != null && _GameManager.SnowMan != null)
        {
            float scale = _GameManager.SnowBall.Scale.x * 100;
            scale = Mathf.Round(scale);
            scale = scale / 100;

            _Force.text = _GameManager.PlayerManager.PlayerHandController.ImpulseForce.ToString();
            _SnowBallScale.text = scale.ToString();

            _SnowBallMinScale.text = _GameManager.SnowMan.MinSnowBallScale.ToString();
            _SnowBallMaxScale.text = _GameManager.SnowMan.MaxSnowBallScale.ToString();

            //_PlayerCash.text = "30";
            _PlayerCash.text = _GameManager.PlayerManager.PlayerCashManager.Cash.ToString();

            base.UpdateUiCanvas();
        }
    }
}
