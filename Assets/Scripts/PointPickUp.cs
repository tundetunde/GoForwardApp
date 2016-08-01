using UnityEngine;
using System.Collections;

public class PointPickUp : MonoBehaviour {
    public AudioClip collectPoints;

    float score = 0;
    AudioSource soundSource;

    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        score = PlayerPrefs.GetInt("Score");
    }

    void AddPoint()
    {
        score = PlayerPrefs.GetInt("Score");
        score++;
        PlayerPrefs.SetInt("Score", (int)score);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            AddPoint();
            transform.position = Vector3.one * 9999999f;
            if(PlayerPrefs.GetInt("Sound") == 1)
                soundSource.PlayOneShot(collectPoints, 1f);
            Destroy(gameObject, collectPoints.length);
        }
    }
}
