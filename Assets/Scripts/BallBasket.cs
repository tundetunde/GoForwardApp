using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class BallBasket : MonoBehaviour {
    public Text blueText;
    public Text yellowText;
    public Text redText;
    public Text greenText;
    public Text orangeText;

    // Use this for initialization
    void Start () {
        GetBasket();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void GetBasket()
    {
        blueText.text = Convert.ToString(PlayerPrefs.GetInt("BlueBalls", 0));
        yellowText.text = Convert.ToString(PlayerPrefs.GetInt("YellowBalls", 0));
        redText.text = Convert.ToString(PlayerPrefs.GetInt("RedBalls", 0));
        greenText.text = Convert.ToString(PlayerPrefs.GetInt("GreenBalls", 0));
        orangeText.text = Convert.ToString(PlayerPrefs.GetInt("OrangeBalls", 0));
    }
}
