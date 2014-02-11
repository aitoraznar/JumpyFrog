using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
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

		GUI.BeginGroup(new Rect(Screen.width/2 - (menuWidth/2), Screen.height/2 - (menuHeight/2), menuWidth, menuHeight));

		GUI.Box(new Rect(0, 0, menuWidth, menuHeight*2), "Men\u00FA principal", boxTitleStyle);
		
		if (GUI.Button(new Rect (50, buttonHeight*1, buttonWidth, buttonHeight), "Jugar", style)) {
			Application.LoadLevel("FirstLevel");
		}
		if(GUI.Button(new Rect(50, buttonHeight*2, buttonWidth, buttonHeight), "Salir", style)){
			Application.Quit();
		}
		
		GUI.EndGroup();
	}
}
