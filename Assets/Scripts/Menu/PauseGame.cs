using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
	
	void Update () {
		if(Input.GetKey(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
		    //pause the game
		    Time.timeScale = 0.0f;
		    //show the pause menu
		    PauseMenuScript pauseScript = gameObject.GetComponent<PauseMenuScript>(); 
		    pauseScript.enabled = true;
		    //disable the cursor
		    Screen.showCursor = false; 
		}
	}
}
