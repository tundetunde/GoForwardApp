using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

    int sound;
	public Image img;
	public Sprite mute, unmute, musicOn;

    void Awake()
    {
        sound = PlayerPrefs.GetInt("Sound", 0);		
		if (sound == 1) {
			img.sprite = unmute;
		} else if(sound == 2){
			img.sprite = musicOn;
        }else{
            img.sprite = mute;
        }
    }

    public void Mute()
    {
        sound = PlayerPrefs.GetInt("Sound");
        switch (sound)
        {
            case 0:
                sound = 1;
                img.sprite = unmute;
                //Set it to 1 and enable just sound
                break;
            case 1:
                //Set it to 2 and start music
                sound = 2;
                img.sprite = musicOn;
                break;
            case 2:
                //reset to 0 and mute sound and music
                sound = 0;
                img.sprite = mute;
                break;
        }
         
        PlayerPrefs.SetInt("Sound", sound);
		PlayerPrefs.Save();
    }
}
