using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

    int sound;
	public Image img;
	public Sprite mute, unmute;

    void Start()
    {
        sound = PlayerPrefs.GetInt("Sound");		
		if (sound == 1) {
			img.sprite = mute;
		} else {
			img.sprite = unmute;
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
