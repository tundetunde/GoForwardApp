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

    void OnCollisionEnter(Collision other)
    {
        // If Pick up then destroy object and Add point to score
        AddPoint();
        StartCoroutine(DestroyPlatform(gameObject));
    }

    IEnumerator DestroyPlatform(GameObject platform)
    {
        //Waiting for 1 second to execute next line(s) of code.
        yield return new WaitForSeconds(0f);
        // Destroying platform
        Destroy(platform);
    }
}
