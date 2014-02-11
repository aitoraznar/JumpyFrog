using UnityEngine;
using System.Collections;

public class GenericMessage : MonoBehaviour {
	
	public string text 	= "Sample text";
	
	public int menuWidth 	= 300;
	public int menuHeight 	= 150;
	public int buttonWidth	= 200;
	public int buttonHeight	= 60;
	
	void OnGUI(){
		Time.timeScale = 0.0f;
		Screen.showCursor = true; 
		
		//layout start
		GUI.BeginGroup(new Rect(Screen.width / 2 - (menuWidth/2), Screen.height / 2 - (menuHeight/2), menuWidth, menuHeight));
		
		//the menu background box
		GUI.Box(new Rect(0, 0, menuWidth, menuHeight), text);
		
		if(GUI.Button(new Rect (50,50, buttonWidth, buttonHeight), "Aceptar")) {
			Debug.Log("Aceptar");
			this.enabled = false;
		    Screen.showCursor = false; //disable the cursor
			
			Time.timeScale = 1.0f; //Resumen the game
		}
		
		GUI.EndGroup();
	}
	
}
