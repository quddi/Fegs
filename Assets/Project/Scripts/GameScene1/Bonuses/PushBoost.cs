using UnityEngine;

public class PushBoost : MonoBehaviour, IBonus
{
    [SerializeField]
    private float force;
    [SerializeField]
    private Transform _mainPlane;
    [SerializeField]
    private PlatformStartOptions _platformStartOptions;
    private int _rotationAngle;
    private Vector3 _pushDirection;

    private void Start()
    {
        _rotationAngle = GetRotationAngle();
        _mainPlane.rotation = Quaternion.Euler(0, _rotationAngle, 0);
        _pushDirection = new Vector3 ((int)Mathf.Sin(Mathf.PI * _rotationAngle / 180f), 0, (int)Mathf.Cos(Mathf.PI * _rotationAngle / 180f));
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<FallOut>() != null)
            Bonus(other.gameObject);
    }
    
    private int GetRotationAngle()
    {
        (int Row, int Column) pitIndexes = LevelGeneration.PitIndexes;
        (int Row, int Column, bool WasChanged) thisIndexes = _platformStartOptions.PositionInGenerationArray;

        (int Row, int Column) difference = (System.Math.Sign(pitIndexes.Row - thisIndexes.Row), 
                                            System.Math.Sign(pitIndexes.Column - thisIndexes.Column));
        int result = 0;

        if (difference == (1, -1) || difference == (0, -1) || difference == (-1, -1))
            result = 180;
        else if (difference == (-1, 1) || difference == (1, 1) || difference == (0, 1))
            result = 0;
        else if (difference == (-1, 0))
            result = 270;
        else if (difference == (1, 0))
            result = 90;

        return result;
    }

    public void Bonus(GameObject feg)
    {
        Rigidbody _entered = feg.GetComponent<Rigidbody>();
        _entered.AddForce(_pushDirection * force, ForceMode.Impulse);
    }
}
