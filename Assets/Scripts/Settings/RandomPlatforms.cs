using UnityEngine;
using UnityEngine.UI;

public class RandomPlatforms : MonoBehaviour
{
    [SerializeField]
    private Toggle _randomToggle;

    private void Start()
    {
        _randomToggle.isOn = PlayerPrefs.HasKey("RandomPlatform") && PlayerPrefs.GetInt("RandomPlatform") == 1;
    }

    public void OnValueChange()
    {
        if (_randomToggle.isOn)
            PlayerPrefs.SetInt("RandomPlatform", 1);
            
        else PlayerPrefs.SetInt("RandomPlatform", 0);
    }
}
