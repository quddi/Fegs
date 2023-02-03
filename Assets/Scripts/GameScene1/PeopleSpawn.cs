using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _allPeople;
    private GameObject[] _chosedPeople;
    public Transform[] _spawnPoints;

    public void SpawnStart()
    {
        _chosedPeople = GetChosenPeople(_allPeople);
        Transform[] _RightSpawnPoints = GetRandomSpawnPoints(_spawnPoints);
        SpawnPeople(_RightSpawnPoints, _chosedPeople); 
    }

    private GameObject[] GetChosenPeople(GameObject[] allPeople)
    {
        List<GameObject> ChosenPeople = new List<GameObject>();
        foreach(int manNumber in Serializer.GameData.NumsOfBoughtPeople)
        {
            ChosenPeople.Add(allPeople[manNumber]);
        }
        return ChosenPeople.ToArray();
    }

    public void SpawnPeople(Transform[] spawnPoints, GameObject[] chosenPeople)
    {
        foreach(Transform point in spawnPoints)
        {
            int k = Random.Range(0, chosenPeople.Length);
            Instantiate(chosenPeople[k], point.position, Quaternion.identity);
        }
    }

    public Transform[] GetRandomSpawnPoints(Transform[] all)
    {
        Transform[] result = new Transform[5];
        int random = Random.Range(0, all.Length / 5) * 5; //выбираем 1 из 5 наборов точек спауна
        for (int i = 0; i < 5; i++)
        {
            result[i] = all[i + random]; //берем 5 точек выбраной позиции, +random - отвечает за выбраный набор точек
        }
        return result;
    }
}
