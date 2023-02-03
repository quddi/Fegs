using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Seller : MonoBehaviour
{
    private const int PLATFORM = 2, DONATE_ITEM = -1, ADD_ITEM = -2;
    [SerializeField]
    private SavedDataVizualizer _dataVisualizer;
    [SerializeField]
    private MainShopVisualizer _shopVisualizer;
    

    public void Buy(ItemScript item)
    {
        if(item.Price == -1)
        {
               //buying donate item
        }
        else if (item.Price == - 2)
        {
               //buying add item
        }
        else
        {
            if (Serializer.GameData.MoneyCount >= item.Price)
            {
                item.ChangeToBought();
                Serializer.GameData.MoneyCount -= item.Price;
                _dataVisualizer.UpdateMoneyCountText();
                switch(item.Type)
                {
                    case 0:
                        Serializer.GameData.NumsOfBoughtPeople.Add(item.ThingNum);
                        break;
                    case 1:
                        Serializer.GameData.NumsOfBoughtBonuses.Add(item.ThingNum);
                        break;
                    case 2:
                        Serializer.GameData.NumsOfBoughtPlatforms.Add(item.ThingNum);
                        Serializer.GameData.ChoosedPlatform = item.ThingNum;
                        _dataVisualizer.SelectChosedPlatform();
                        _shopVisualizer.GiveMessageOnBuyingPage("Chosen!");
                        break;
                }
            }
            else
            {
                _shopVisualizer.GiveMessageOnBuyingPage("No money!");
            } 
            
        }
        Serializer.SaveData();
    }

    public void ChoosePlatform(ItemScript item)
    {
        Serializer.GameData.ChoosedPlatform = item.ThingNum;
        Serializer.SaveData();
        _dataVisualizer.SelectChosedPlatform();
    }

    
}
