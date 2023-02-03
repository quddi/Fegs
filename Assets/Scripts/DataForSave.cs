using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataForSave
{
    public List<int> NumsOfBoughtPeople { get; set; } = new List<int>() { 0 };
    public List<int> NumsOfBoughtBonuses { get; set; } = new List<int>() { };
    public List<int> NumsOfBoughtPlatforms { get; set; } = new List<int>() { 0 };
    
    public int MoneyCount { get; set; } = 0;
    public int ChoosedPlatform { get; set; } = 0;
    public int BestScore { get; set; } = 0;
}
