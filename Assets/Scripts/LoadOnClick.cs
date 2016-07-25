using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	public void LoadScene(int level)
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("GameScene");
    }
}
