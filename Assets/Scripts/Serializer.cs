using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public static class Serializer
{
    public static DataForSave GameData = new DataForSave();
    private static string path = Application.persistentDataPath + "savefile.xml";

    public static void SaveData()
    {
        XElement MoneyCount = new XElement("MoneyCount");
        XElement ChoosedPlatform = new XElement("ChoosedPlatform");
        XElement BestScore = new XElement("BestScore");

        XElement BoughtPeople = new XElement("BoughtPeopleNumbers");
        XElement BoughtBonuses = new XElement("BoughtBonusesNumbers");
        XElement BoughtPlatforms = new XElement("BoughtPlatformsNumbers");

        XElement Root = new XElement("Root");

        MoneyCount.Add(GameData.MoneyCount);
        ChoosedPlatform.Add(GameData.ChoosedPlatform);
        BestScore.Add(GameData.BestScore);

        FeelXElement(ref BoughtPeople, GameData.NumsOfBoughtPeople);
        FeelXElement(ref BoughtBonuses, GameData.NumsOfBoughtBonuses);     // Создаем элементы, которые хранят купленые предметы
        FeelXElement(ref BoughtPlatforms, GameData.NumsOfBoughtPlatforms); //

        Root.Add(MoneyCount);
        Root.Add(ChoosedPlatform);
        Root.Add(BestScore);
        Root.Add(BoughtPeople);
        Root.Add(BoughtBonuses);
        Root.Add(BoughtPlatforms);

        XDocument DataDocument = new XDocument(Root);

        File.WriteAllText(path, DataDocument.ToString());
    }

    private static void FeelXElement(ref XElement xElementToFeel, IEnumerable<int> thingsThatFeel)
    {
        foreach(int boughtThingsNumber in thingsThatFeel)
        {
            XElement Instance = new XElement("Instance");
            Instance.Add(boughtThingsNumber);
            xElementToFeel.Add(Instance);
        }
    }

    public static void GetData()
    {
        retry:
        if(File.Exists(path))
        {
            XElement Root = new XElement("Root");
            Root = XDocument.Parse(File.ReadAllText(path)).Element("Root");

            GameData.MoneyCount = int.Parse(Root.Element("MoneyCount").Value);
            GameData.ChoosedPlatform = int.Parse(Root.Element("ChoosedPlatform").Value);
            GameData.BestScore = int.Parse(Root.Element("BestScore").Value);

            GameData.NumsOfBoughtPeople = GetListFromXElement(Root.Element("BoughtPeopleNumbers"));
            GameData.NumsOfBoughtBonuses = GetListFromXElement(Root.Element("BoughtBonusesNumbers"));
            GameData.NumsOfBoughtPlatforms = GetListFromXElement(Root.Element("BoughtPlatformsNumbers"));
        }
        else
        {
            SaveData(); //Создаем файл с начальными данными и сохраняем его
            goto retry; 
        }
    }

    private static List<int> GetListFromXElement(XElement listToParse)
    {
        List<int> ParsedData = new List<int>();
        foreach(XElement element in listToParse.Elements("Instance"))
        {
            ParsedData.Add(int.Parse(element.Value));
        }
        ParsedData.Sort();
        return ParsedData;
    }
}
