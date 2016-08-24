using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UseBall : MonoBehaviour {
    public enum COLOURS
    {
        NONE,
        BLUE,
        YELLOW,
        RED,
        GREEN,
        ORANGE,
    }

    public Button starButtonRed, starButtonGreen, starButtonBlue;
    public Button starButtonYellow, starButtonOrange, starButtonStandard;
    public static UseBall Instance { set; get; }
    public static COLOURS colour;

    void Awake()
    {
        if (PlayerPrefs.GetInt("RedBalls") == 0)
            starButtonRed.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("BlueBalls") == 0)
            starButtonBlue.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("YellowBalls") == 0)
            starButtonYellow.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("GreenBalls") == 0)
            starButtonGreen.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("OrangeBalls") == 0)
            starButtonOrange.gameObject.SetActive(false);

    }

    public void SetBlueBall()
    {
        if(PlayerPrefs.GetInt("BlueBalls") > 0)
        {
            colour = COLOURS.BLUE;
            starButtonBlue.transform.GetChild(0).GetComponent<Image>().enabled = true;
            starButtonRed.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonGreen.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonYellow.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonOrange.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonStandard.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    public void SetYellowBall()
    {
        if(PlayerPrefs.GetInt("YellowBalls") > 0)
        {
            colour = COLOURS.YELLOW;
            starButtonYellow.transform.GetChild(0).GetComponent<Image>().enabled = true;
            starButtonBlue.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonRed.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonGreen.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonOrange.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonStandard.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    public void SetGreenBall()
    {
        if(PlayerPrefs.GetInt("GreenBalls") > 0)
        {
            colour = COLOURS.GREEN;
            starButtonGreen.transform.GetChild(0).GetComponent<Image>().enabled = true;
            starButtonYellow.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonBlue.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonRed.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonOrange.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonStandard.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    public void SetOrangeBall()
    {
        if(PlayerPrefs.GetInt("OrangeBalls") > 0)
        {
            colour = COLOURS.ORANGE;
            starButtonOrange.transform.GetChild(0).GetComponent<Image>().enabled = true;
            starButtonGreen.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonYellow.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonBlue.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonRed.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonStandard.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    public void SetRedBall()
    {
        if(PlayerPrefs.GetInt("RedBalls") > 0)
        {
            colour = COLOURS.RED;
            starButtonRed.transform.GetChild(0).GetComponent<Image>().enabled = true;
            starButtonOrange.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonGreen.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonYellow.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonBlue.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonStandard.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    public void SetStandardBall()
    {
        if (PlayerPrefs.GetInt("RedBalls") > 0)
        {
            colour = COLOURS.NONE;
            starButtonStandard.transform.GetChild(0).GetComponent<Image>().enabled = true;
            starButtonRed.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonOrange.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonGreen.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonYellow.transform.GetChild(0).GetComponent<Image>().enabled = false;
            starButtonBlue.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

}
