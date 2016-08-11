using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

    int sound;
	public Image img;
	public Sprite mute, unmute;

    void Awake()
    {
        sound = PlayerPrefs.GetInt("Sound", 0);		
		if (sound == 1) {
			img.sprite = unmute;
		} else {
			img.sprite = mute;
		}
    }

    public void Mute()
    {
        sound = PlayerPrefs.GetInt("Sound");
        if (sound == 1)
        {
            sound = 0;
			img.sprite = mute;
        }
        else
        {
            sound = 1;
			img.sprite = unmute;
        }
            
        PlayerPrefs.SetInt("Sound", sound);
		PlayerPrefs.Save();
    }
}
