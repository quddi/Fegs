using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    public Text ScoreText;
    private int _score = 0;
    public Slider TimeLineSlider;
    public int MutipleScore;
    private int _bestScore;

    private int _earnedThisGameBonusMoney;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        _score +=  MutipleScore;
        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreText.text = "Score: " + _score + "   Best Score: " + _bestScore;
    }

    private void Update()
    {
        if (_score == 30)
        {
            TimeLineSlider.GetComponent<FinishTimer>().StartedTimer = true;
            MutipleScore = 5;
        }
    }

    public void AddBonusMoney(int count)
    {
        if(count > 0)
            _earnedThisGameBonusMoney += count;
    }

    public void SaveProgress()
    {
        if (_bestScore < _score)
        {
            _bestScore = _score;
        }
        Serializer.GameData.MoneyCount += _earnedThisGameBonusMoney + _score;
        Serializer.SaveData();
        FirebaseConnectionSingleton.FirebaseConnection.Save();
    }

    public int GetScore()
    {
        return _score;
    }
}
