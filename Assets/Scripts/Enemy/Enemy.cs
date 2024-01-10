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
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _spd);

        // TODO: Find nearest target
        // TODO: Attack
        // TODO: Die
    }
}