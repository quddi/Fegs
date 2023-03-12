using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private const string TutorialPassedKeyName = "TutorialPassed";
    private const int _timeToWaitInSeconds = 1;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(TutorialPassedKeyName))
            Destroy(gameObject);

        PlayerPrefs.SetInt(TutorialPassedKeyName, 1);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            WaitAndDestroy(1);
            StartCoroutine("WaitAndDestroy", _timeToWaitInSeconds);
        }
            
    }

    private IEnumerator WaitAndDestroy(int timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        Destroy(gameObject);
    }
}
