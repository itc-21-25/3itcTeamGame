using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject Head;
    GameObject Body;
    GameObject Legs;
    [field: SerializeField] Transform ComponentParent;

    int _dmg;
    int _stm;
    int _spd;
    int _wgt;
    int _knockback;
    Transform _target;
    Transform _player;
    Rigidbody _rb;
    float _cd = 0;
    float _maxCd = 2;
    void Start()
    {
        // Stats
        SelectParts();
        _dmg = Head.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Damage + Body.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Damage + Legs.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Damage;
        _stm = Head.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Stamina + Body.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Stamina + Legs.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Stamina;
        _spd = Head.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Speed + Body.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Speed + Legs.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Speed;
        _wgt = Head.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Weight + Body.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Weight + Legs.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Weight;
        _knockback = (_dmg * _spd) - _wgt;
        _player = GameManager.Get().PlayerManager.transform;

        for (int i = 0; i < ComponentParent.childCount; i++)
            Destroy(ComponentParent.GetChild(0).gameObject);

        Instantiate(Head, ComponentParent);
        Instantiate(Body, ComponentParent);
        Instantiate(Legs, ComponentParent);

        _rb = GetComponent<Rigidbody>();
        // TODO: Find nearest target
        StartCoroutine("FindEnemy");
    }

    void Update()
    {
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _spd);
        if (transform.position.y <= -15)
        {
            _stm = -10;
            Die();
        }
        _cd -= Time.deltaTime;
        if (_cd <= 0)
        {

        }
        // TODO: Attack
        // TODO: Die
    }

    public void ResetTarget() => _target = null;
    Transform FindNearest()
    {
        LevelController _levelController = ((List<LevelController>)LevelManager.Instance.LevelControllers)[LevelManager.Instance.ActualLevelID];

        float _closestDis = float.MaxValue;
        Transform _closestEnemy = ((List<Enemy>)_levelController.Enemies)[0].transform;
        foreach (Enemy _enemy in _levelController.Enemies)
        {
            if (!_enemy.Equals(this))
            {
                float _currDis = Vector3.Distance(transform.position, _enemy.transform.position);
                if (_currDis <= _closestDis)
                {
                    _closestDis = _currDis;
                    _closestEnemy = _enemy.transform;
                }
            }
        }

        if (Vector3.Distance(transform.position, _player.position) <= Vector3.Distance(transform.position, _closestEnemy.position))
            _closestEnemy = _player.transform;

        return _closestEnemy;
    }
    IEnumerator FindEnemy()
    {
        while (true)
        {
            _target = FindNearest();

            yield return new WaitForSeconds(2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats _stats = collision.gameObject.GetComponent<PlayerManager>().PlayerStats;
            _stats.Hit(_dmg);
            _rb.AddForce(collision.impulse.normalized * (_knockback));

            Hit(_stats);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy _enemy = collision.gameObject.GetComponent<Enemy>();
            _enemy.Hit(_dmg);
            _rb.AddForce(collision.impulse.normalized * (_knockback));

            Hit(_enemy._dmg);
        }
    }

    private void Hit(PlayerStats _stats)
    {
        _stm -= _stats.Beyblade.GetTotalStat("Damage");

        Die();
    }
    private void Hit(int dmg)
    {
        _stm -= dmg;

        Die();
    }
    private void Die()
    {
        if (_stm <= 0)
        {
            ((List<LevelController>)(GameManager.Get().LevelManager.LevelControllers))[GameManager.Get().LevelManager.ActualLevelID].KilledEnemy(this);
            Destroy(gameObject);
        }
    }
    private void SelectParts()
    {
        foreach (var item in GameManager.Get().CreateBeybladeBuild())
        {
            switch (item.GetComponent<BeybladeComponentHolder>().BeybladeComponent.Part) {
                case BeybladeParts.Top:
                    Head = item.gameObject;
                    break;
                case BeybladeParts.Mid:
                    Body = item.gameObject;
                    break;
                case BeybladeParts.Bottom:
                    Legs = item.gameObject;
                    break;
                default:
                    Debug.LogError("tak to je v pièi silnì :)");
                    break;
            }

        }
    }
}