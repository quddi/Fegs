using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesContainer : MonoBehaviour
{
    public void LoadGameScene1()
    {
        SceneManager.LoadScene("GameScene1");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
