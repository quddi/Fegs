using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataForSave
{
    public List<int> NumsOfBoughtPeople = new List<int>() { 0 };
    public List<int> NumsOfBoughtBonuses = new List<int>() { };
    public List<int> NumsOfBoughtPlatforms = new List<int>() { 0 };
    
    public int MoneyCount = 0;
    public int ChoosedPlatform = 0;
    public int BestScore = 0;
}
