using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class BeybladePartSelection : MonoBehaviour
{
    [SerializeField] private List<GameObject> topParts = new List<GameObject>();
    [SerializeField] private List<GameObject> bodyParts = new List<GameObject>();
    [SerializeField] private List<GameObject> bottomParts = new List<GameObject>();
    
    [SerializeField] private GameObject topHolder;
    [SerializeField] private GameObject bodyHolder;
    [SerializeField] private GameObject bottomHolder;
    [SerializeField] private List<GameObject> holders = new List<GameObject>();

    int topIndex = 0;
    int bottomIndex = 0;
    int bodyIndex = 0;


    private void Start()
    {
        holders.Add(topHolder);
        holders.Add(bodyHolder);
        holders.Add(bottomHolder);
        SetHolderPrefabs();
    }
    void ClearHolders()
    {
        foreach (var item in holders)
        {
            for(int i = 0;i < item.transform.childCount; i++)
            {
            Destroy(item.transform.GetChild(i).gameObject);
            }
        }
    }
    void SetHolderPrefabs()
    {
        ClearHolders();
        Instantiate(topParts[topIndex], topHolder.transform);
        Instantiate(bodyParts[bodyIndex], bodyHolder.transform);
        Instantiate(bottomParts[bottomIndex], bottomHolder.transform);
    }
    public void NextTopPart()
    {
        if(topIndex == topParts.Count - 1)
        {
            topIndex = 0;
        }
        else
        {
            topIndex++;
        }
        SetHolderPrefabs();
    }
    public void NextBodyPart()
    {
        if (bodyIndex == bodyParts.Count - 1)
        {
            bodyIndex = 0;
        }
        else
        {
            bodyIndex++;
        }
        SetHolderPrefabs();
    }
    public void NextBottomPart()
    {
        if (bottomIndex == bottomParts.Count - 1)
        {
            bottomIndex = 0;
        }
        else
        {
            bottomIndex++;
        }
        SetHolderPrefabs();
    }
    public void BackTopPart()
    {
        if (topIndex == 0)
        {
            topIndex = topParts.Count-1;
        }
        else
        {
            topIndex--;
        }
        SetHolderPrefabs();
    }
    public void BackBodyPart()
    {
        if (bodyIndex == 0)
        {
            bodyIndex = bodyParts.Count - 1;
        }
        else
        {
            bodyIndex--;
        }
        SetHolderPrefabs();
    }
    public void BackBottomPart()
    {
        if (bottomIndex == 0)
        {
            bottomIndex = bottomParts.Count - 1;
        }
        else
        {
            bottomIndex--;
        }
        SetHolderPrefabs();
    }
}
