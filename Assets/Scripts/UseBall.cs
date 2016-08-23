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

    public static UseBall Instance { set; get; }
    public static COLOURS colour;
    public Text text;

    public void SetBlueBall()
    {
        if(PlayerPrefs.GetInt("BlueBalls") > 0)
        {
            colour = COLOURS.BLUE;
            text.text = "Current Ball: Blue";
        }
    }

    public void SetYellowBall()
    {
        if(PlayerPrefs.GetInt("YellowBalls") > 0)
        {
            colour = COLOURS.YELLOW;
            text.text = "Current Ball: Yellow";
        }
    }

    public void SetGreenBall()
    {
        if(PlayerPrefs.GetInt("GreenBalls") > 0)
        {
            colour = COLOURS.GREEN;
            text.text = "Current Ball: Green";
        }
    }

    public void SetOrangeBall()
    {
        if(PlayerPrefs.GetInt("OrangeBalls") > 0)
        {
            colour = COLOURS.ORANGE;
            text.text = "Current Ball: Orange";
        }
    }

    public void SetRedBall()
    {
        if(PlayerPrefs.GetInt("RedBalls") > 0)
        {
            colour = COLOURS.RED;
            text.text = "Current Ball: Red";
        }
    }

}
