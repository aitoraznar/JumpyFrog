using UnityEngine;
using System.Collections;
 
public class LifeBar : MonoBehaviour {
 
	public Rect lifeBarRect;
	public Rect lifeBarLabelRect;
	public Rect lifeBarBackgroundRect;
	public Texture2D lifeBarBackground;
	public Texture2D lifeBar;
	 
	public GUIStyle labelStyle;
	 
	private HealthScript controller;
	private float LifeBarWidth;
	private float LifeBarheight;
	
	void Start(){
	    controller = GetComponent<HealthScript>();	 
		LifeBarWidth = Screen.width/4;
		LifeBarheight = Screen.height/8;
	}
	 
	void OnGUI(){
		this.lifeBarBackgroundRect.x = Screen.width-LifeBarWidth-10;
		this.lifeBarBackgroundRect.y = 10;
	    this.lifeBarBackgroundRect.width = LifeBarWidth+4;
		this.lifeBarBackgroundRect.height= LifeBarheight+5;
	    GUI.DrawTexture(lifeBarBackgroundRect, lifeBarBackground);
		
		this.lifeBarRect.x = Screen.width-LifeBarWidth-8;
		this.lifeBarRect.y = 12;
	    this.lifeBarRect.width = (LifeBarWidth * (controller.hp/100));
		this.lifeBarRect.height = LifeBarheight;
		GUI.DrawTexture(lifeBarRect, lifeBar);
	 
		lifeBarLabelRect.x = Screen.width-(LifeBarWidth/2)-50;
		lifeBarLabelRect.y=10;
		lifeBarLabelRect.width = 50;
		lifeBarLabelRect.height = 20;
		
		string lifeLabel = controller.hp+"%"; 
		labelStyle.fontSize = 20+(Screen.height/15);
		labelStyle.normal.textColor = Color.white;
		GUI.Label(lifeBarLabelRect, lifeLabel, labelStyle);
	 
	}
 
}
