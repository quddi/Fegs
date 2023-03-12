using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject _plane;
    [SerializeField]
    private GameObject _pitPlatform;
    private GameObject[,] _createdPlanes = new GameObject[ROWS_COUNT, COLUMNS_COUNT];
    [SerializeField]
    private float _sideLength, _planePosY;
    private int _chosedPlatformNumber;
    public static (int Row, int Column) PitIndexes { get; private set; }

    private const int MIN_ARRAY_INDEX = 0, ROWS_COUNT = 3, COLUMNS_COUNT = 4;

    private void Start()
    {
        _chosedPlatformNumber = Serializer.GameData.ChoosedPlatform;
        GeneratePlatformsArray(_chosedPlatformNumber);
    }

    private GameObject[,] GeneratePlatformsArray(int chosedPlatform)
    {
        CreatePit();

        for (int i = 0; i < ROWS_COUNT; i++)
        {
            for (int j = 0; j < COLUMNS_COUNT; j++)
            {
                if (_createdPlanes[i, j] == null) 
                {
                    Vector3 positionToPlacePlatform = new Vector3(i * _sideLength, _planePosY, j * _sideLength);
                    _createdPlanes[i, j] = Instantiate(_plane, positionToPlacePlatform, Quaternion.identity);
                    _createdPlanes[i, j].GetComponent<PlatformStartOptions>().PositionInGenerationArray = (i, j, true);
                }
            }
        }

        return _createdPlanes;
    }

    private void CreatePit()
    {
        PitIndexes = (Random.Range(MIN_ARRAY_INDEX, ROWS_COUNT), Random.Range(MIN_ARRAY_INDEX, COLUMNS_COUNT));

        Vector3 positionToPlacePit = new Vector3(PitIndexes.Row * _sideLength, _planePosY, PitIndexes.Column * _sideLength);
        
        _createdPlanes[PitIndexes.Row, PitIndexes.Column] = Instantiate(_pitPlatform, positionToPlacePit, Quaternion.identity);
    }
}
