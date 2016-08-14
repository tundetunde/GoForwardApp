using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public GameObject ball;
    Text txt;
    float score = 0;
	// Use this for initialization
	void Start () {
        txt = gameObject.GetComponent<Text>();
        txt.text = "" + (int)score;
    }
	
	// Update is called once per frame
	void Update () {
        if(ball.transform.position.y < 0)
            SceneManager.LoadScene("GameOverScene");
        score = PlayerPrefs.GetInt("Score");
        txt.text = "" + (int)score;
        //PlayerPrefs.SetInt("Score", (int)score);
    }
}
