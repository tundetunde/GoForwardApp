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
        if (isLoggedIn())
            img.sprite = leaderboard;
        else
            img.sprite = login;
    }

    public void LogIn()
    {
        if (isLoggedIn())
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboardString);
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Debug.Log("Login Sucess");
                    img.sprite = leaderboard;
                }
                else
                {
                    Debug.Log("Login failed");
                }
            });

        }
        
    }

    bool isLoggedIn()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            return true;
        return false;
    }

    public void OnLogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }
}
