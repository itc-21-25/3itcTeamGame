using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] BeybladeComponent Head;
    [field: SerializeField] BeybladeComponent Body;
    [field: SerializeField] BeybladeComponent Legs;
    [field: SerializeField] Transform ComponentParent;

    int _dmg;
    int _stm;
    int _spd;
    int _wgt;
    int _knockback;
    Transform _target;
    Transform _player;
    void Start()
    {
        // Stats
        _dmg = Head.Damage + Body.Damage + Legs.Damage;
        _stm = Head.Stamina + Body.Stamina + Legs.Stamina;
        _spd = Head.Speed + Body.Speed + Legs.Speed;
        _wgt = Head.Weight + Body.Weight + Legs.Weight;
        _knockback = (_dmg * _spd) - _wgt;
        _player = GameManager.Get().PlayerManager.transform;

        for (int i = 0; i < ComponentParent.childCount; i++)
            Destroy(ComponentParent.GetChild(0).gameObject);

        Instantiate(Head.Prefab, ComponentParent);
        Instantiate(Body.Prefab, ComponentParent);
        Instantiate(Legs.Prefab, ComponentParent);
    }

    void Update()
    {
        // TODO: Find nearest target
        if (_target == null)
            SetTarget();
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _spd);
        // TODO: Attack
        // TODO: Die
    }

    public void SetTarget()
    {
        if (_target == null)
            _target = FindNearest();
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
}