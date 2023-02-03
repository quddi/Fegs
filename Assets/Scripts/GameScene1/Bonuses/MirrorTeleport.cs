using UnityEngine;

public class MirrorTeleport : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _additiveMoving;

    private const float CALCULATED_DISPLACEMENT_X = 10, CALCULATED_DISPLACEMENT_Z = 15;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out FallOut x))
        {
            Debug.Log("sss");
            Transform transform = other.GetComponent<Transform>();

            float newX = GetNewPosition(transform.position.x, CALCULATED_DISPLACEMENT_X, _direction.x);
            float newZ = GetNewPosition(transform.position.z, CALCULATED_DISPLACEMENT_Z, _direction.y);

            Vector3 newPosition = new Vector3(newX, transform.position.y, newZ);
            transform.position = newPosition;
        }
    }

    private float GetNewPosition(float currentPosition, float calculatedDisplacement, float axisDirection)
    {
        return Mathf.Pow(-1, axisDirection) * (currentPosition - calculatedDisplacement) + axisDirection * _additiveMoving + calculatedDisplacement;
    }
}
