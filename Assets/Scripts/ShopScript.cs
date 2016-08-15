using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {
    public GameObject menu;
    public static ShopScript Instance { set; get; }

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

    public void GoToShop()
    {
        menu.SetActive(true);
    }

    public void BuyRedBalls(int amount)
    {

        //IAPManager.Instance.BuyRedBalls(amount);
    }

    public void BuyBlueBalls(int amount)
    {
        //IAPManager.Instance.BuyBlueBalls(amount);
    }

    public void BuyYellowBalls(int amount)
    {
        //IAPManager.Instance.BuyYelllowBalls(amount);
    }

    public void BuyOrangeBalls(int amount)
    {
        //IAPManager.Instance.BuyOrangeBalls(amount);
    }

    public void BuyGreenBalls(int amount)
    {
        //IAPManager.Instance.BuyGreenBalls(amount);
    }
}
