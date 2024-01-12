using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.GraphView;
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

    /* 
     * returns -1 when no valid stat was found :)
     */
    public int GetTotalStat(string stat)
    {
        switch(stat)
        {
            case "Damage":
                return Top.Damage + Mid.Damage + Bottom.Damage;
            case "Stamina":
                return Top.Stamina + Mid.Stamina + Bottom.Stamina;
            case "Speed":
                return Top.Speed + Mid.Speed + Bottom.Speed;
            case "Weight":
                return Top.Weight + Mid.Weight + Bottom.Weight;
            default:
                return -1;
        }
    }
   public void SetComp(BeybladeComponent comp)
    {
        switch(comp.Part)
        {
            case BeybladeParts.Top:
                Top = comp;
                break;
            case BeybladeParts.Mid:
                Mid = comp;
                break;
            case BeybladeParts.Bottom:
                Bottom = comp;
                break;
            default:
                Debug.LogError("tak to je v pièi silnì :)");
                break;
        }
    }
}
public enum BeybladeParts
{
    Top = 0,
    Mid = 1,
    Bottom = 2
}