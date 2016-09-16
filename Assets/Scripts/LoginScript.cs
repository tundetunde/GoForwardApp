using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class LoginScript : MonoBehaviour {
    public Image img;
    public Sprite login, leaderboard;
    public string leaderboardString;


    void Awake()
	{		
		PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
    }

	void Update()
	{		
		if (isLoggedIn())
			img.sprite = leaderboard;
		else
			img.sprite = login;
	}

    public void LogIn()
    {    
		if (!PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.Authenticate (SignInCallback, false);
		} else {
			((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboardString);
		}
        
    }

	public void SignInCallback(bool success) {
		if (success) {
			Debug.Log("Login Sucess");
			if (isLoggedIn ()) {
				img.sprite = leaderboard;
				UpdateScoreOnDevice();
			} else {
				img.sprite = login;
			}			
			}
		else {
			UpdateScoreOnDevice();
				Debug.Log("Login failed");
			}
	}

	void UpdateScoreOnDevice(){
		PlayGamesPlatform.Instance.LoadScores(
						leaderboardString, LeaderboardStart.PlayerCentered,1, LeaderboardCollection.Public, LeaderboardTimeSpan.AllTime,
		(LeaderboardScoreData data) => {
            Debug.Log (data.Valid);
			int gscore = (int)data.PlayerScore.value;
			int pscore = PlayerPrefs.GetInt("HighScore");//device score
			if(data.Valid){
				if(gscore!=null){
						if (gscore > pscore)
					{
							PlayerPrefs.SetInt("HighScore", gscore);
					}
					else{
						PlayGamesPlatform.Instance.ReportScore(pscore,leaderboardString,
						(bool sucess) =>
						{
							Debug.Log("Leaderboard updated: " + sucess);
						});
					}
			}}
		});
	}

    bool isLoggedIn()
    {
		if (PlayGamesPlatform.Instance.localUser.authenticated)
			return true;
		return false;
    }

}
