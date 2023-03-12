using System.Collections.Generic;
using UnityEngine;

public class PlatformStartOptions : MonoBehaviour
{
    [Header("У префаба все платформы, препятствия и бонусы должны быть выключены!")]
    [SerializeField]
    private MeshRenderer _mainMesh;
    [SerializeField]
    private GameObject[] _allPlatforms, _allBonuses, _allWalls;
    private (int Row, int Column, bool WasChanged) _positionInGenerationArray = (0, 0, false);
    public (int Row, int Column, bool WasChanged) PositionInGenerationArray 
    {
        get { return _positionInGenerationArray; }
        set 
        { 
            if(_positionInGenerationArray.WasChanged == false)
                _positionInGenerationArray = value;
        }
    } 

    void Start()
    {
        int possibleBonusesCount = Serializer.GameData.NumsOfBoughtBonuses.Count;
        if (possibleBonusesCount > 0 && Random.Range(0, 8) == 0) //шанс 0.125 что будет бонус
        {
            CreateBonus(possibleBonusesCount);
        }
        else
        {
            CreatePlatform(Serializer.GameData.ChoosedPlatform);
            GetComponent<PeopleSpawn>().SpawnStart();
        }
    }

    private void CreateBonus(int bonusesCount)
    {
        int _randomlyChosedBonus = Random.Range(0, bonusesCount);
        for (int i = 0; i < _allBonuses.Length; i++)
        {
            if (Serializer.GameData.NumsOfBoughtBonuses[_randomlyChosedBonus] == i)
            {
                _allBonuses[i].SetActive(true);
            } 
        }
    }

    private void CreatePlatform(int platformNum)
    {
        for (int i = 0; i < _allPlatforms.Length; i++)
        {
            if (i == platformNum) _allPlatforms[i].SetActive(true);
        }
        MaybeCreateWalls(_allWalls.Length);
    }

    private void MaybeCreateWalls(int numOfWalls)
    {
        if (Random.Range(0, 5) == 1) // шанс 0.2 что появится препятствие
        {
            _allWalls[Random.Range(0, numOfWalls)].SetActive(true);
        }
    }

}
