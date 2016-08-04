using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public void LoadScene(int level)
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("BluePickUp", 0);
        PlayerPrefs.SetInt("RedPickUp", 0);
        PlayerPrefs.SetInt("GreenPickUp", 0);
        PlayerPrefs.SetInt("OrangePickUp", 0);
        PlayerPrefs.SetInt("YellowPickUp", 0);
        SceneManager.LoadScene("GameScene");
    }
}
