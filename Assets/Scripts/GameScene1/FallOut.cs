using UnityEngine;

public class FallOut : MonoBehaviour
{
    public bool MustFall = false;
    private bool _fallActivated = false;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (MustFall && !_fallActivated)
        {
            _rigidBody.velocity = new Vector3(0, 0, 0);
            _rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            _fallActivated = true;
        }
    }
}
