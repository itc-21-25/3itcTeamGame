using UnityEngine;

[CreateAssetMenu(menuName = "BeybladeComponents/Component")]
public class Beyblade : ScriptableObject
{
    [field: SerializeField] int Damage;
    [field: SerializeField] int Stamina;
    [field: SerializeField] int Speed;
    [field: SerializeField] int Weight;
    [field: SerializeField] GameObject Prefab;


}