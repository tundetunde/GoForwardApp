using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    void Awake()
    {
        UseBall.colour = UseBall.COLOURS.NONE;
    }

    public void LoadScene(int level)
    {
        //AdManager.Instance.ShowFullScreenAds();
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("BluePickUp", 0);
        PlayerPrefs.SetInt("RedPickUp", 0);
        PlayerPrefs.SetInt("GreenPickUp", 0);
        PlayerPrefs.SetInt("OrangePickUp", 0);
        PlayerPrefs.SetInt("YellowPickUp", 0);
        PlayerPrefs.SetInt("SuckerPower", 0);
        SceneManager.LoadScene("GameScene");
    }
}
