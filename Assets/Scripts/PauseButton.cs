using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public bool isPaused;
	public GameObject menu;

	// Use this for initialization
	void Start () {
		isPaused = false;
	}
	
	public void Halt () {
        Time.timeScale = 0;
		menu.SetActive(true);
		isPaused = true;
	}
	
	public void Resume (){
		Time.timeScale = 1;
		menu.SetActive(false);
		isPaused = false;
	}

	public void ExitGame(){
		Application.Quit ();
	}
	
	void Update	()	{
		if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Home)
			|| Input.GetKey(KeyCode.Menu)) {
				isPaused = true;
				Halt();
		}
	}
	
	void OnApplicationPause (bool state) {
		 isPaused = true;
		Halt();
	}
	
	void OnApplicationFocus(bool focus){
		isPaused = true;
		Halt();
    }
}