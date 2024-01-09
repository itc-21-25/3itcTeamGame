using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerSpawn = null;
    [SerializeField] private GameObject _SnowBallSpawn = null;
    [SerializeField] private GameObject _SnowManSpawn = null;
    
    [SerializeField] private float _MinScale = 0f;
    [SerializeField] private float _MaxScale = 0f;
    [SerializeField] private int LevelAddCoins;

    private LevelManager _LevelManager = null;
    private GameManager _GameManager = null;
    private PlayerManager _PlayerManager = null;

    private List<GameObject> _MyGameobjects = new List<GameObject>();

    private bool _LevelStart = false;
    private bool UzJede = false;

    public void Init()
    {
        _GameManager = GameManager.Get();
        _LevelManager = _GameManager.LevelManager;
        _PlayerManager = _GameManager.PlayerManager;
        gameObject.SetActive(true);
    }

    //public void UpdateLevel()
    //{
    //    if (_LevelStart)
    //    {

    //         if (_GameManager.SnowBall != null && _GameManager.SnowBall.Scale.x > _MaxScale && UzJede == false)
    //        {

    //            UzJede = true;


    //           FindObjectOfType<LaserDeratizator>().StartLaser();
    //        }


    //        //if (_GameManager.LevelManager.LaserDeratizator.hitPlayer == true)
    //        //{
    //        //    _GameManager.PlayerManager.PlayerAudioManager.PlayDeadAudio();
    //        //    _GameManager.UiManager.CrossHairUiController.Unload();
    //        //    _GameManager.UiManager.GameOverUi.Load();
    //        //    _GameManager.PauseGame();
    //        //    EndLevel();
    //        //}

    //    }
    //}




    public void UpdateLevel()
    {
        if (_LevelStart)
        {
            if (_GameManager.SnowBall != null && _GameManager.SnowBall.Scale.x > _MaxScale && UzJede == false)
            {
                UzJede = true;

                StartCoroutine(StartLaserAndKill());
            }

            // ...
        }
    }



    private IEnumerator StartLaserAndKill()
    {
        FindObjectOfType<LaserDeratizator>().StartLaser();

        // Poèkejte, dokud se StartLaser nedokonèí
        while (FindObjectOfType<LaserDeratizator>().hitPlayer == false)
        {
            yield return null;
        }

        // StartLaser je dokonèen, zavolejte funkci Kill
        UzJede = false;
        Kill();
    }



    public void Kill()

    {
       
        _GameManager.PlayerManager.PlayerAudioManager.PlayDeadAudio();
            _GameManager.UiManager.CrossHairUiController.Unload();
            _GameManager.UiManager.GameOverUi.Load();
            _GameManager.PauseGame();
            EndLevel();
}

    public void StartLevel()
    {
        FindObjectOfType<LaserDeratizator>().ResetLaser();
        
        PlayerCashManager playerCashManager = FindObjectOfType<PlayerCashManager>();

        playerCashManager.AddCoins(LevelAddCoins);
        _GameManager.PlayerManager.PlayerHandController.SetDefaultImpulseForce();

        _MyGameobjects.Add(Instantiate(_LevelManager.SnowBallPrefab, _SnowBallSpawn.transform.position, _SnowBallSpawn.transform.rotation, transform));
        GameObject snowMan = Instantiate(_LevelManager.SnowManPrefab, _SnowManSpawn.transform.position, _SnowManSpawn.transform.rotation, transform);
        SnowMan snowManScript = null;
        if (snowMan.TryGetComponent(out snowManScript))
        {
            snowManScript.SetMaxScale(_MaxScale);
            snowManScript.SetMinScale(_MinScale);
        }
        _MyGameobjects.Add(snowMan);

        _PlayerManager.SetPosition(_PlayerSpawn.transform.position);
        _LevelStart = true;
    }

    public void EndLevel()
    {
        _LevelStart = false;
        for (int i = 0; i < _MyGameobjects.Count; i++)
        {
            Destroy(_MyGameobjects[i]);
        }

        gameObject.SetActive(false);
    }
}
