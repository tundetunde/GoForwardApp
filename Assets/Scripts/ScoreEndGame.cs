using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

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
		if (PlayGamesPlatform.Instance.localUser.authenticated)
			return true;
		return false;
    }

    public void OnAddScoreToLeaderBorad()
    {
		// Submit leaderboard scores, if authenticated
		if (PlayGamesPlatform.Instance.localUser.authenticated)
		{
			// Note: make sure to add 'using GooglePlayGames'
			PlayGamesPlatform.Instance.ReportScore(score,leaderboard,
				(bool success) =>
				{
					Debug.Log("Leaderboard updated: " + success);
				});
		}
    }
}
