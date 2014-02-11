using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	
	public string title 	= "Title";
	public int menuWidth;
	public int menuHeight;
	public int buttonWidth;
	public int buttonHeight;
	
	void OnGUI () {
		menuWidth = (int)(Screen.width * 0.75);
		menuHeight = (int)(Screen.height * 0.75);
		buttonWidth = menuWidth - 100;
		buttonHeight = menuHeight / 4;

		GUIStyle boxTitleStyle = new GUIStyle(GUI.skin.box);
		boxTitleStyle.normal.textColor = Color.white;
		boxTitleStyle.fontSize = 20 + (Screen.height / 15);
		
		GUIStyle style = new GUIStyle(GUI.skin.button);
		style.normal.textColor = Color.white;
		style.fontSize = 20 + (Screen.height / 15);

		GUI.BeginGroup(new Rect(Screen.width / 2 - (menuWidth/2), Screen.height / 2 - (menuHeight/2), menuWidth, menuHeight));
		
		GUI.Box(new Rect(0, 0, menuWidth, menuHeight), title, boxTitleStyle);
		
		//main menu return button (level 0)
		if(GUI.Button(new Rect(55, buttonHeight*1, buttonWidth, buttonHeight), "Reiniciar", style)){
			Application.LoadLevel("FirstLevel");
		}
		
		//quit button
		if(GUI.Button(new Rect(55, buttonHeight*2, buttonWidth, buttonHeight), "Men\u00FA principal", style)){
			Application.LoadLevel("MainMenu");
		}
		
		GUI.EndGroup();
	}
}
