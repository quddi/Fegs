using UnityEngine;

public class CoinBoost : MonoBehaviour, IBonus
{
    [Header("Сколько раз можно получить")]
    [SerializeField]
    private int _freeCoins;
    [Header("Сколько за раз можно получить")]
    [SerializeField]
    private int _freeCoinsPerTake;
    private ScoreLogic _moneyCounter;
    [SerializeField]
    private ParticleSystem _earnedParticles;

    private void Start()
    {
        _moneyCounter = GameObject.Find("Destroyer").GetComponent<ScoreLogic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_freeCoins > 0 && other.GetComponent<FallOut>() != null)
            Bonus(other.gameObject);
    }

    public void Bonus(GameObject feg)
    {
        _earnedParticles.Play();
        _moneyCounter.AddBonusMoney(_freeCoinsPerTake);
        _freeCoins--;
    }
}
