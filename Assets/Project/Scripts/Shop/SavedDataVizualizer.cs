using UnityEngine.UI;
using UnityEngine;

public class SavedDataVizualizer : MonoBehaviour
{
    [SerializeField]
    private Text _moneyCountText;
    [SerializeField]
    private Transform _peopleItems, _bonusesItems, _platformsItems;
    
    private void Awake()
    {
        Serializer.GetData();
    }

    private void Start()
    {
        UpdateMoneyCountText();
        SelectChosedPlatform();
        LoadBoughtLists();
    }

    public void SelectChosedPlatform()
    {
        foreach(Transform item in _platformsItems)
        {
            ItemScript itemScript = item.GetComponent<ItemScript>();
            bool choosed = itemScript.ThingNum == Serializer.GameData.ChoosedPlatform;
            
            itemScript.ChangeChoosed(choosed);
        }
    }

    private void LoadBoughtLists() // idk how to make better
    {
        foreach(int numThing in Serializer.GameData.NumsOfBoughtPeople)
            _peopleItems.GetChild(numThing).GetComponent<ItemScript>().ChangeToBought();
        
        foreach (int numThing in Serializer.GameData.NumsOfBoughtBonuses)
            _bonusesItems.GetChild(numThing).GetComponent<ItemScript>().ChangeToBought();
        
        foreach (int numThing in Serializer.GameData.NumsOfBoughtPlatforms)
            _platformsItems.GetChild(numThing).GetComponent<ItemScript>().ChangeToBought();
    }
    

    public void UpdateMoneyCountText()
    {
        _moneyCountText.text = Serializer.GameData.MoneyCount.ToString();
    }
}
