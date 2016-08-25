using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ShopScript : MonoBehaviour {
    public GameObject menu;
    public static ShopScript Instance { set; get; }
    public Text blue, red, green, yellow, orange;

    public enum COLOURS
    {
        BLUE,
        YELLOW,
        RED,
        GREEN,
        ORANGE,
        NONE
    }

    public static COLOURS colour { set; get; }

    void Awake()
    {
        //TestUseButtons();
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void GoToShop(int number)
    {
        switch (number)
        {
            case 0:
                colour = COLOURS.BLUE;
                break;
            case 1:
                colour = COLOURS.YELLOW;
                break;
            case 2:
                colour = COLOURS.RED;
                break;
            case 3:
                colour = COLOURS.ORANGE;
                break;
            case 4:
                colour = COLOURS.GREEN;
                break;
        }
        menu.SetActive(true);
    }

    public void BuyBalls(int amount)
    {
        switch (colour)
        {
            case COLOURS.BLUE:
                BuyBlueBalls(amount);
                break;
            case COLOURS.YELLOW:
                BuyYellowBalls(amount);
                break;
            case COLOURS.RED:
                BuyRedBalls(amount);
                break;
            case COLOURS.GREEN:
                BuyGreenBalls(amount);
                break;
            case COLOURS.ORANGE:
                BuyOrangeBalls(amount);
                break;
        }
    }

    private void BuyRedBalls(int amount)
    {

        IAPManager.Instance.BuyRedBalls(amount);
        Debug.Log("Buying Red Balls");
        red.text = Convert.ToString(PlayerPrefs.GetInt("RedBalls"));
    }

    private void BuyBlueBalls(int amount)
    {
        IAPManager.Instance.BuyBlueBalls(amount);
        Debug.Log("Buying Blue Balls");
        blue.text = Convert.ToString(PlayerPrefs.GetInt("BlueBalls"));
    }

    private void BuyYellowBalls(int amount)
    {
        IAPManager.Instance.BuyYelllowBalls(amount);
        Debug.Log("Buying Yellow Balls");
        yellow.text = Convert.ToString(PlayerPrefs.GetInt("YellowBalls"));
    }

    private void BuyOrangeBalls(int amount)
    {
        IAPManager.Instance.BuyOrangeBalls(amount);
        Debug.Log("Buying Orange Balls");
        orange.text = Convert.ToString(PlayerPrefs.GetInt("OrangeBalls"));
    }

    private void BuyGreenBalls(int amount)
    {
        IAPManager.Instance.BuyGreenBalls(amount);
        Debug.Log("Buying Green Balls");
        green.text = Convert.ToString(PlayerPrefs.GetInt("GreenBalls"));
    }

    private void TestUseButtons()
    {
        PlayerPrefs.SetInt("BlueBalls", 1);
        PlayerPrefs.SetInt("YellowBalls", 1);
        PlayerPrefs.SetInt("GreenBalls", 1);
        PlayerPrefs.SetInt("RedBalls", 1);
        PlayerPrefs.SetInt("OrangeBalls", 1);
    }

    public void BackToShopMenu()
    {
        menu.gameObject.SetActive(false);
    }
}
