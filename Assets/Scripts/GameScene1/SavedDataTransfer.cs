using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedDataTransfer : MonoBehaviour
{
    public void Awake()
    {
        Serializer.GetData();
        GetChoosedPlatformIndex();
    }

    private void GetChoosedPlatformIndex()
    {
        if (PlayerPrefs.HasKey("RandomPlatform") && PlayerPrefs.GetInt("RandomPlatform") == 1)
        {
            List<int> boughtPlatforms = Serializer.GameData.NumsOfBoughtPlatforms;
            Serializer.GameData.ChoosedPlatform = boughtPlatforms[Random.Range(0, boughtPlatforms.Count)];
        }
    }
}
