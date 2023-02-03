using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinishTimer : MonoBehaviour
{
    public bool StartedTimer;
    private Slider _thisSlider;

    public ScoreLogic Saver;

    private void Start()
    {
        _thisSlider = GetComponent<Slider>();
    }

    void FixedUpdate()
    {
        if (StartedTimer) _thisSlider.value--;
        if (_thisSlider.value == 0)
        {
            StartedTimer = false;
            StartCoroutine("FinishLevel");
        }
    }

    IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(1);
        Saver.SaveProgress();
        SceneManager.LoadScene("GameScene1");
    }
}
