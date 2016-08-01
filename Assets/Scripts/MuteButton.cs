using UnityEngine;
using System.Collections;

public class MuteButton : MonoBehaviour {

    int sound;
    public void Mute()
    {
        sound = PlayerPrefs.GetInt("Sound");
        if (sound == 1)
            sound = 0;
        else
            sound = 1;
        PlayerPrefs.SetInt("Sound", sound);
    }
}
