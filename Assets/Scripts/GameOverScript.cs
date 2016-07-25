using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public void LoadScene(int level)
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("GameScene");
    }
}
