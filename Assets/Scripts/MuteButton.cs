using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

    public Text text;
    int sound;

    void Start()
    {
        sound = PlayerPrefs.GetInt("Sound");
        if (sound == 1)
            text.text = "Sound Off";
        else
            text.text = "Sound On";
    }

    public void Mute()
    {
        sound = PlayerPrefs.GetInt("Sound");
        if (sound == 1)
        {
            sound = 0;
            text.text = "Sound On";
        }
        else
        {
            sound = 1;
            text.text = "Sound Off";
        }
            
        PlayerPrefs.SetInt("Sound", sound);
    }
}
