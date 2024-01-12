using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BeybladeComponents/Component")]
public class BeybladeComponent : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; } = 0;
    [field: SerializeField] public int Stamina { get; private set; } = 0;
    [field: SerializeField] public int Speed { get; private set; } = 0;
    [field: SerializeField] public int Weight { get; private set; } = 0;
    [field: SerializeField] public GameObject Prefab { get; private set; }

    public void SetPlayerBody()
    {
        Prefab = BeybladePartSelection.playerParts[1];
    }
    public void SetPlayerTop()
    {
        Prefab = BeybladePartSelection.playerParts[0];
    }
    public void SetPlayerBottom()
    {
        Prefab = BeybladePartSelection.playerParts[2];
    }
}
