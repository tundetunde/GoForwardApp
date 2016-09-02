using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

    int sound;
    // Use this for initialization
    AudioSource soundSource;
    public AudioClip music;
    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
    }

    void Start () {
        DontDestroyOnLoad(gameObject);
        sound = PlayerPrefs.GetInt("Sound", 0);
        if(sound == 2)
        {
            if (!soundSource.isPlaying)
                soundSource.Play(0);
        }
        else
        {
            if (soundSource.isPlaying)
                soundSource.Stop();
        }
    }
	
	// Update is called once per frame
	void Update () {
        sound = PlayerPrefs.GetInt("Sound");
        if (sound == 2)
        {
            if (!soundSource.isPlaying)
                soundSource.Play(0);
        }
        else
        {
            if (soundSource.isPlaying)
                soundSource.Stop();
        }  
    }
}
