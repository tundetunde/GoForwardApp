using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    void Start()
    {
         //AdManager.Instance.ShowBanner();
         //AdManager.Instance.ShowFullScreenAds();
    }

	public void LoadScene(int level)
    {
        PlayerPrefs.SetInt("FullScreenAds", 1);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("BluePickUp", 0);
        PlayerPrefs.SetInt("RedPickUp", 0);
        PlayerPrefs.SetInt("GreenPickUp", 0);
        PlayerPrefs.SetInt("OrangePickUp", 0);
        PlayerPrefs.SetInt("YellowPickUp", 0);
        PlayerPrefs.SetInt("SuckerPower", 0);
        PlayerPrefs.GetInt("BlueBalls", 0);
        PlayerPrefs.GetInt("RedBalls", 0);
        PlayerPrefs.GetInt("GreenBalls", 0);
        PlayerPrefs.GetInt("YellowBalls", 0);
        PlayerPrefs.GetInt("OrangeBalls", 0);
        if(PlayerPrefs.GetInt("FirstTime", 0) == 0)
            PlayerPrefs.SetInt("FirstTime", 1);
        SceneManager.LoadScene("GameScene");
    }
}
