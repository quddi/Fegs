using UnityEngine;

public class CursorMover : MonoBehaviour
{
    [SerializeField]
    private Collider _sphereCollider;
    private RaycastHit _hitObject;
    private Transform _thisTransform, _circleTransform;
    public GameObject SphereCursor;
    public float CursorHeight;
    private int layerMaskOnlyPlayer = 1 << 8;

    void Start()
    {
        _thisTransform = GetComponent<Transform>();
        _circleTransform = SphereCursor.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _sphereCollider.enabled = true;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(_ray, out _hitObject, Mathf.Infinity, layerMaskOnlyPlayer);
            _circleTransform.position = new Vector3(_hitObject.point.x, CursorHeight, _hitObject.point.z);
        }
        else _sphereCollider.enabled = false;
    }
}
