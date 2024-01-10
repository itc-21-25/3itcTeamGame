using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "BeybladeComponents/Component")]
public class BeybladeComponent : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; } = 0;
    [field: SerializeField] public int Stamina { get; private set; } = 0;
    [field: SerializeField] public int Speed { get; private set; } = 0;
    [field: SerializeField] public int Weight { get; private set; } = 0;
    [field: SerializeField] public GameObject Prefab { get; private set; }
}

[CreateAssetMenu(menuName = "BeybladeComponents/Beyblade")]
public class Beyblade : ScriptableObject
{
    [field: SerializeField] public BeybladeComponent Top { get; private set; } = null;
    [field: SerializeField] public BeybladeComponent Mid { get; private set; } = null;
    [field: SerializeField] public BeybladeComponent Bottom { get; private set; } = null;

    public BeybladeComponent GetBBComponent(BeybladeParts bbParts)
    {
        switch(bbParts)
        {
            case BeybladeParts.Top:
                return Top;
            case BeybladeParts.Mid:
                return Mid;
            case BeybladeParts.Bottom:
                return Bottom;
            default:
                Debug.LogError("tak to je v pièi silnì :)");
                return null;
        }
    }
}
public enum BeybladeParts
{
    Top = 0,
    Mid = 1,
    Bottom = 2
}