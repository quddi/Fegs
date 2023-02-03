using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public int ThingNum, Type;
    [Header("0 - Standart thing")]
    [Header("-1 - Donate thing")]
    [Header("-2 - Thing that player can get watching an add")]
    public int Price;
    public Text PriceText, BoughtText; //Children objects
    public bool IsBought;
    public Image CoinImage, ChosedImage;
    [SerializeField]
    private MainShopVisualizer _shopVisualizer;
    public GiveBuyInformation BuyButton;

    private void Start()
    {
        switch(Price)
        {
            case -1:
                PriceText.text = "Donate Thing";
                break;
            case -2:
                PriceText.text = "Add thing";
                break;
            default:
                PriceText.text = Price.ToString();
                break;
        }
          
    }

    public void OnButtonClick()
    {
        _shopVisualizer.ChangeBuyingPage(this.GetComponent<ItemScript>());
    }

    public void ChangeToBought()
    {
        IsBought = true;
        _shopVisualizer.ChangeBuyButtonToItemThatIsBought(PriceText.text, IsBought);
        _shopVisualizer.GetComponent<MainShopVisualizer>().ChangeRotatingItem(PriceText.text, ThingNum, Type);
        CoinImage.gameObject.SetActive(false);
        PriceText.gameObject.SetActive(false);
        BoughtText.gameObject.SetActive(true);
    }
    
    public void ChangeChoosed(bool chosed)
    {
        if (chosed)
        {
            if(Type == 2) PlayerPrefs.SetInt("ChosedPlatform", ThingNum);
            ChosedImage.gameObject.SetActive(true);
        }
        if (!chosed)
        {
            ChosedImage.gameObject.SetActive(false);
        }
    }
}
