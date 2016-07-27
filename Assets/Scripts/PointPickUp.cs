using UnityEngine;
using System.Collections;

public class PointPickUp : MonoBehaviour {

    float score = 0;
    // Use this for initialization
    void Start () {
	    score = PlayerPrefs.GetInt("Score");
    }

    void AddPoint()
    {
        score++;
        PlayerPrefs.SetInt("Score", (int)score);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            AddPoint();
            Destroy(gameObject);
        }
    }
}
