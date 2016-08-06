using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.UI;

public class LoginScriptEndSceneScript : MonoBehaviour {
    public Text loginText;
    public Text LeaderBoard;

    void Awake()
    {
        if (isLoggedIn())
        {
            loginText.text = "Log Out";
            LeaderBoard.gameObject.SetActive(true);
        }
        else
        {
            loginText.text = "Login";
            LeaderBoard.gameObject.SetActive(false);
        }
            
    }

    public void LogIn()
    {
        if (isLoggedIn())
        {
            loginText.text = "Login";
            OnLogOut();
            LeaderBoard.gameObject.SetActive(false);
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    loginText.text = "Log Out";
                    LeaderBoard.gameObject.SetActive(true);
                    Debug.Log("Login Sucess");
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
