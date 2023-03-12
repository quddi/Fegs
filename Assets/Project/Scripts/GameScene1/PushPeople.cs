using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushPeople : MonoBehaviour
{
    private Transform _thisTransform;
    private Rigidbody _thisRigidBody;

    [SerializeField]
    private float _pushForceCoeficient;

    void Start()
    {
        _thisRigidBody = GetComponent<Rigidbody>();
        _thisTransform = GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector3 _pushForce = (collision.transform.position - _thisTransform.position) * _pushForceCoeficient;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(_pushForce, ForceMode.Impulse);
        }
    }

    
}
