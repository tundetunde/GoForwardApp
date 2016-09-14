using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;

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
			//			
			if (isLoggedIn())
				img.sprite = leaderboard;
			else
				img.sprite = login;
			
//			PlayGamesPlatform.Instance.LoadScores(
//				leaderboardString,
//	            (data) => {
//					
//	            Debug.Log (data.Valid);
//
//	            int gscore = data.PlayerScore.formattedValue;
//
//				if(gscore!=null){
//					if (gscore > PlayerPrefs.GetInt("HighScore"))
//					{
//							PlayerPrefs.SetInt("HighScore", data.gscore);
//					}
//					else{
//						PlayGamesPlatform.Instance.ReportScore(PlayerPrefs.GetInt("HighScore"),leaderboardString,
//							(bool sucess) =>
//							{
//								Debug.Log("Leaderboard updated: " + sucess);
//							});
//					}
//				}
//			});
			}
			else {
				Debug.Log("Login failed");
			}
	}

    bool isLoggedIn()
    {
		if (PlayGamesPlatform.Instance.localUser.authenticated)
			return true;
		return false;
    }

}
