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
        if (_MyCanvas.enabled)
        {
            base.UpdateUiCanvas();
        }
    }
}
