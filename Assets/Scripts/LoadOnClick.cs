using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    void Start()
    {
        AdManager.Instance.ShowBanner();
    }

	public void LoadScene(int level)
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Sound", 1);
        SceneManager.LoadScene("GameScene");
    }
}
