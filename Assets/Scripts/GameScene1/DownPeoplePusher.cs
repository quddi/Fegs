using UnityEngine;


public class DownPeoplePusher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<FallOut>().MustFall = true;
        }
    }
}
