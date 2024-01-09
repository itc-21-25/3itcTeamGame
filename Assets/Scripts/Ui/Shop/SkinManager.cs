using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : BaseUiController
{
    [System.Serializable]
    public class Skin
    {
        public Material skin;
        public int price;
        public GameObject PriceText;
        public Button BuyButton;
        public int id;
        public bool seknuto;
    }

    [SerializeField] Skin[] skins;

    public Skin[] ArraySkins()
    {
        return skins;
    }

    public void EquipSkin(int id)
    {
        FindObjectOfType<SnowBall>().gameObject.GetComponent<MeshRenderer>().material = skins[id].skin;
        int skinPrice = skins[id].price;
        
        //skins[id].BuyButton
        // použijte skinPrice pro zpracování ceny skinu
    }

    private int PlayerCash;


    public void getCoins(int coins)
    {
        PlayerCash = coins;
    }

    private void Update()
    {

    }


    private void Start()
    {
        // Tady jsem vzdal život a veškeré oop programování, vypadaly mi všechny vlasy a zaèal jsem mít deprese.


        foreach (var skin in skins)
        {
            skin.BuyButton.onClick.AddListener(() =>
            {
                if (skin.seknuto == true)
                {
                    EquipSkin(skin.id);
                    skin.BuyButton.GetComponentInChildren<TextMeshProUGUI>().fontSizeMin = 40;
                    skin.BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = " Sekni to znova.";
                    
                }
                else
                {
                    skin.BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = PlayerCash >= skin.price ? " Sekl si to." : "A LOVE?";
                    if (PlayerCash >= skin.price)
                    {
                        FindObjectOfType<PlayerCashManager>().ReduceCoins(skin.price);
                        skin.seknuto = true;
                        EquipSkin(skin.id);
                    }
                }


            });
        }
    }
}