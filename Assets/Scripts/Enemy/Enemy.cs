using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] BeybladeComponent Head;
    [field: SerializeField] BeybladeComponent Body;
    [field: SerializeField] BeybladeComponent Legs;

    int _dmg;
    int _stm;
    int _spd;
    int _wgt;
    int _knockback;
    Transform _target;
    void Start()
    {
        // Stats
        _dmg = Head.Damage + Body.Damage + Legs.Damage;
        _stm = Head.Stamina + Body.Stamina + Legs.Stamina;
        _spd = Head.Speed + Body.Speed + Legs.Speed;
        _wgt = Head.Weight + Body.Weight + Legs.Weight;
        _knockback = (_dmg * _spd) - _wgt;
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

    private void SetTarget() => _target = FindNearest().transform;
    public void SetTarget(Enemy enemy)
    {
        if (_target == null)
            _target = enemy.transform;
    }
    public void ResetTarget() => _target = null;
    Enemy FindNearest()
    {
        LevelController _levelController = ((List<LevelController>)LevelManager.Instance.LevelControllers)[LevelManager.Instance.ActualLevelID];

        float _closestDis = float.MaxValue;
        Enemy _closestEnemy = ((List<Enemy>)_levelController.Enemies)[0];
        foreach (Enemy _enemy in _levelController.Enemies)
        {
            float _currDis = Vector3.Distance(transform.position, _enemy.transform.position);
            if (_currDis <= _closestDis)
            {
                _closestDis = _currDis;
                _closestEnemy = _enemy;
            }
        }
        return _closestEnemy;
    }
}