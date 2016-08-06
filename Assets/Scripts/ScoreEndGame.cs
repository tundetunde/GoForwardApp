using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;

public class ScoreEndGame : MonoBehaviour {

    int score = 0;
    int highScore = 0;
    public Text ScoreText;
    public Text HighScoreText;
    public string leaderboard;

    // Use this for initialization
    void Start () {
        score = PlayerPrefs.GetInt("Score");
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            if (isLoggedIn())
                OnAddScoreToLeaderBorad();
        }
            
        highScore = PlayerPrefs.GetInt("HighScore");
    }
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "Score: " + score;
        HighScoreText.text = "HighScore: " + highScore;
    }

    bool isLoggedIn()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            return true;
        return false;
    }

    public void OnAddScoreToLeaderBorad()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, leaderboard, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("Update Score Success");

                }
                else
                {
                    Debug.Log("Update Score Fail");
                }
            });
        }
    }
}
