using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Text codeInput;
    [SerializeField]
    private Messager messanger;
    private CodeChecker codeChecker;

    private void Start()
    {
        Serializer.GetData();
        codeChecker = GetComponent<CodeChecker>();
    }

    public void TryInputCodeButton()
    {
        string code = codeInput.text;
        if (codeChecker.codeIsAvaliableAndActive(code) && !PlayerPrefs.HasKey(code))
        {
            switch(code)
            {
                case "HAPPY2022":
                    Serializer.GameData.ChoosedPlatform = 11;
                    Serializer.GameData.NumsOfBoughtPlatforms.Add(11);
                    Serializer.GameData.MoneyCount += 1000;
                    Serializer.SaveData();
                    PlayerPrefs.SetString(code, "activated");
                    break;
                case "M0NEY":
                    Serializer.GameData.MoneyCount += 10000;
                    Serializer.SaveData();
                    break;
            }
            messanger.ShowMessage("Code activated!");
        }
        else messanger.ShowMessage("Code is incorrect or not more available!");
    }



    public void BackButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
