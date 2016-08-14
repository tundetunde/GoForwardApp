using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public Image img;
	public Sprite play, pause;
	public bool click;
	
	// Use this for initialization
	void Start () {
		click = true;
	}
	
	public void Halt () {
		if (Time.timeScale == 1)
         {
             Time.timeScale = 0;
			 img.sprite = play;
			 click = false;
         }
         else
         {
             Time.timeScale = 1;
			 img.sprite = pause;
			 click = true;
         }
	}
}
