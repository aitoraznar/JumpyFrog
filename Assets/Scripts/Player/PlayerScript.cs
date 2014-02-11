using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float velocity = 3f;
	//Jump rate
	public float jumpRate = 2f;

	public float jumpHeight = 250f;

	//Jump cooldown
	private float jumpCooldown;

	public int puntuation = 0;
	public GUIStyle puntuationLabelStyle;

	
	// Use this for initialization
	void Start () {
		jumpCooldown = 0f;
	}

	// Update is called once per frame
	void Update () {
	
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal") * Time.deltaTime * velocity;
		//Debug.Log(inputX + " - " + transform.position.y + " - " + transform.position.z);
		transform.Translate (inputX, 0, 0);

		jumpCooldown += Time.deltaTime;

		if(click() && canJump()){
			jump();
			jumpCooldown = 0f;
		}

		// 6 - Make sure we are not outside the camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
	
	}

	void OnGUI(){
		string puntuationLabel = ""+puntuation;
		puntuationLabelStyle.fontSize = 20+(Screen.height/10);
		puntuationLabelStyle.normal.textColor = Color.blue;
		GUI.Label(new Rect(10, 10, 50, 50), puntuationLabel, puntuationLabelStyle);
		
	}

	public void jump(){
		rigidbody2D.AddForce(Vector3.up * jumpHeight);
	}

	public bool click() {
		return Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown (0);
	}

	public bool canJump(){
		return jumpCooldown >= jumpRate;
	}



}
