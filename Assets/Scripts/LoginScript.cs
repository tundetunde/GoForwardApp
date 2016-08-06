using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;

public class LoginScript : MonoBehaviour {
    public Text loginText;

    void Awake()
    {
        if (isLoggedIn())
            loginText.text = "Log Out";
        else
            loginText.text = "Login";
    }

    public void LogIn()
    {
        if (isLoggedIn())
        {
            loginText.text = "Login";
            OnLogOut();
            
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    loginText.text = "Log Out";
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
