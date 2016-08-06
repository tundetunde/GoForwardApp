using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class LeaderboardScript : MonoBehaviour {

    public string leaderboard;

    // Use this for initialization
    void Awake() {
        if (isLoggedIn())
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    bool isLoggedIn()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            return true;
        return false;
    }

    public void OnShowLeaderBoard()
    {
        //        Social.ShowLeaderboardUI (); // Show all leaderboard
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard); // Show current (Active) leaderboard
    }
}
