using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBuyInformation : MonoBehaviour
{
    [SerializeField]
    private Seller _dataSaver;
    [HideInInspector]
    public ItemScript Item;
    private const int PLATFORM = 2;
    [SerializeField]
    private MainShopVisualizer _shopVisualChanger;

    public void Buy()
    {
        if(Item.IsBought && Item.Type == PLATFORM)
        {
            _dataSaver.ChoosePlatform(Item);
            _shopVisualChanger.GiveMessageOnBuyingPage("Chosen!");
        }
        else if (!Item.IsBought)
        {
            _dataSaver.Buy(Item);
        }
        
    }
}
