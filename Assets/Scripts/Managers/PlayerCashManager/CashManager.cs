using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public int Cash => cash;
    [SerializeField] private int cash;

    public int AddCoins(int amount)
    {
        cash += amount;
        return cash;
    }

    public int GetCash()
    {
        return cash;
    }

    public int RemoveCoins(int amount)
    {
        if (cash - amount >= 0)
        {
            cash -= amount;
        }
        else
        {
            cash = 0;
        }
        return cash;
    }

}
