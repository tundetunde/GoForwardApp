using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreEndGame : MonoBehaviour {

    int score = 0;
    int highScore = 0;
    public Text ScoreText;
    public Text HighScoreText;
    // Use this for initialization
    void Start () {
        score = PlayerPrefs.GetInt("Score");
        if (score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", score);
        highScore = PlayerPrefs.GetInt("HighScore");
    }
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "Score: " + score;
        HighScoreText.text = "HighScore: " + score;
    }
}
