using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

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