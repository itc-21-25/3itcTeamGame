using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BeybladeCreator : MonoBehaviour
{
    public static BeybladeCreator beybladeCreator { get; private set; }
    private GameObject playerBeyblade = new GameObject("PlayerBeyblade");

    private BeybladeCreator()
    {
        
    }
    private void Awake()
    {
        if (beybladeCreator == null)
        {
            beybladeCreator = new BeybladeCreator();
        }
    }
    public GameObject CreatePlayerBeyBlade(GameObject top,GameObject body, GameObject bottom) {
        top.transform.parent = playerBeyblade.transform;
        body.transform.parent = playerBeyblade.transform;
        bottom.transform.parent = playerBeyblade.transform;
        return playerBeyblade;
    }
}
