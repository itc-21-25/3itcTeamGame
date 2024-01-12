using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "BeybladeComponents/Component")]
public class BeybladeComponent : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; } = 0;
    [field: SerializeField] public int Stamina { get; private set; } = 0;
    [field: SerializeField] public int Speed { get; private set; } = 0;
    [field: SerializeField] public int Weight { get; private set; } = 0;
    [field: SerializeField] public BeybladeParts Part { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
}