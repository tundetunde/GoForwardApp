using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToShop : MonoBehaviour {

	public void LoadShop()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
