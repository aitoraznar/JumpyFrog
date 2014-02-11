using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour{
	
	public int menuWidth 	= 600;
	public int menuHeight 	= 300;
	public int buttonWidth	= 500;
	public int buttonHeight	= 60;
	public AudioClip pauseMusic;
	
	GUISkin newSkin;
	//Texture2D logoTexture;
	
	void Start(){
		if(pauseMusic){
			audio.Stop();
			audio.clip = pauseMusic;
			audio.loop = true;
			audio.Play();
		}
	}
	
	public void thePauseMenu(){
		//layout start
		GUI.BeginGroup(new Rect(Screen.width / 2 - (menuWidth/2), Screen.height / 2 - (menuHeight/2), menuWidth, menuHeight));
		
		//the menu background box
		GUI.Box(new Rect(0, 0, menuWidth, menuHeight), "Juego en pausa");
		//logo picture
		//GUI.Label(new Rect(15, 10, 300, 68), logoTexture);
		
		///////pause menu buttons
		//game resume button
		if(GUI.Button(new Rect(55, 40, buttonWidth, buttonHeight), "Continuar")){
			//resume the game
			Screen.showCursor = false; //disable the cursor
			Time.timeScale = 1.0f;
			this.enabled = false;
		}
		
		//main menu return button (level 0)
		if(GUI.Button(new Rect(55, 120, buttonWidth, buttonHeight), "Reiniciar")){
			Application.LoadLevel("FirstLevel");
		}
		
		//quit button
		if(GUI.Button(new Rect(55, 200, buttonWidth, buttonHeight), "Men\u00FA principal")){
			Application.LoadLevel("MainMenu");
		}
		
		//layout end
		GUI.EndGroup();
	}
	
	
	void OnGUI (){
		//StartCoroutine(PauseCoroutine());
		
		//load GUI skin
		GUI.skin = newSkin;
		
		//show the mouse cursor
		Screen.showCursor = true;
		
		//run the pause menu script
		thePauseMenu();
	}
	
	IEnumerator PauseCoroutine() {
        while (true){
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){
                //resume the game
				Screen.showCursor = false; //disable the cursor
				Time.timeScale = 1.0f;
				this.enabled = false;
            }    
            yield return null;    
        }
    }

}