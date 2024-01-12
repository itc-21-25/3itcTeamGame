using UnityEngine;

public class BaseUiController : MonoBehaviour
{
    protected Canvas _MyCanvas = null;
    protected GameManager _GameManager = null;
    protected UiManager _UiManager = null;

    private void Start()
    {
        _MyCanvas = GetComponent<Canvas>();
        _GameManager = GameManager.Get();
        _UiManager = _GameManager.UiManager;
    }
    public virtual void Init()
    {
        _MyCanvas = GetComponent<Canvas>();
        _GameManager = GameManager.Get();
        _UiManager = _GameManager.UiManager;
    }

    public virtual void Load()
    {
        if (!_MyCanvas.enabled)
        {
            _MyCanvas.enabled = true;
        }
    }

    public virtual void Unload()
    {
        if (_MyCanvas.enabled)
        {
            _MyCanvas.enabled = false;
        }
    }

    public virtual void UpdateUiCanvas()
    {

    }


}
