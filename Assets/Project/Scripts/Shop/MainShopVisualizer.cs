using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainShopVisualizer : MonoBehaviour
{
    public Animator ShopPagesAnimator, MessageBoxAnimator;
    public GameObject ShopPlatforms, ShopPeople, ShopBonuses;
    public GameObject[] IconsOfPeople, IconsOfBonuses, IconsOfPlatforms, _allShows;
    public Text TextOfBuyButton, BoughtText;
    public GiveBuyInformation BuyButton;
    [SerializeField]
    private GameObject _coinImageOnButton;
    [SerializeField]
    private Text _messageBoxText;

    public void ChangePageAnimation(int a)
    {
        ShopPagesAnimator.SetInteger("GoVariable", a);
    }

    private void Start()
    {
        Serializer.SaveData();
    }

    public void ChangeRotatingItem(string price, int numObject, int numthing) //включаем нужный обьект для кручения
    {
        switch (numthing) 
        {
            case 0:
                foreach (GameObject item in IconsOfPeople)
                {
                    item.SetActive(false);
                }
                IconsOfPeople[numObject].SetActive(true);
                break;
            case 1:
                foreach (GameObject item in IconsOfBonuses)
                {
                    item.SetActive(false);
                }
                IconsOfBonuses[numObject].SetActive(true);
                break;
            case 2:
                foreach (GameObject item in IconsOfPlatforms)
                {
                    item.SetActive(false);
                }
                IconsOfPlatforms[numObject].SetActive(true);
                break;
        }
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ChangeShopCategory(int a)
    {
        for (int i = 0; i < 3; i++)
        {
            _allShows[i].SetActive(i == a);
        }
        switch (a)
        {
            case 0:
                ShopPlatforms.SetActive(false);
                ShopBonuses.SetActive(false);
                ShopPeople.SetActive(true);
                break;
            case 1:
                ShopPlatforms.SetActive(false);
                ShopBonuses.SetActive(true);
                ShopPeople.SetActive(false);
                break;
            case 2:
                ShopPlatforms.SetActive(true);
                ShopBonuses.SetActive(false);
                ShopPeople.SetActive(false);
                break;
        }
    }

    public void ChangeBuyButtonToItemThatIsBought(string price, bool bought) // говорит, какой будет большая кнопка покупки
    {
        if (bought)
        {
            _coinImageOnButton.SetActive(false);
            TextOfBuyButton.enabled = false;
            BoughtText.enabled = true;
        }
        else
        {
            _coinImageOnButton.SetActive(true);
            TextOfBuyButton.enabled = true;
            BoughtText.enabled = false;
            string[] a = ("Buy: " + price).Split(new string[] {" ", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            TextOfBuyButton.text = a[0] + " " + a[1];
        }
    }
    

    public void GiveMessageOnBuyingPage(string text)
    {
        _messageBoxText.text = text;
        MessageBoxAnimator.SetBool("IsAnimating", true);
    }


    public void ChangeBuyingPage(ItemScript item)
    {
        BuyButton.Item = item;
        ChangePageAnimation(1);
        ChangeRotatingItem(item.PriceText.text, item.ThingNum, item.Type);
        ChangeBuyButtonToItemThatIsBought(item.PriceText.text, item.IsBought);
    }
}