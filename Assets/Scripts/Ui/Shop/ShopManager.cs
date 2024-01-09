using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static SkinManager;

public class ShopManager : BaseUiController
{


    private bool shopOpen = false;
    [SerializeField] private TextMeshProUGUI coinsText;
    private int coins;
    //[SerializeField] private TextMeshProUGUI SkinButton;
    [SerializeField] private SkinManager _SkinManager = null;
    public SkinManager SkinManager => _SkinManager;

    private void Start()
    {

        foreach (var skin in _SkinManager.ArraySkins())
        {
            skin.PriceText.GetComponent<TextMeshProUGUI>().text = skin.price.ToString();
           
            
           
        }

    }

    public void ShopBuy(int id)
    {
        
    }

    private void ShopOpen()
    {
        Load();
        _GameManager.PauseGame();
        shopOpen = true;
        Debug.Log("OTEVÍRÁ SE OBCHOD");


    }

    public void ShopClose()
    {

        Unload();
        _GameManager.UnpauseGame();
        shopOpen = false;
        Debug.Log("ZAVÍRÁ SE OBCHOD");
    }

   
        

    private void Update()
    {
        coins = _GameManager.PlayerManager.PlayerCashManager.Cash;
        _SkinManager.getCoins(_GameManager.PlayerManager.PlayerCashManager.Cash);
        coinsText.text = coins.ToString();


        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!shopOpen)
            {
                ShopOpen();
            }
            else
            {
                ShopClose();
            }
        }
    }
}

