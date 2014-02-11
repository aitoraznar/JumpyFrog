using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private bool hasSpawn;
	private MoveScript moveScript;
	
	void Awake() {
		// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<MoveScript>();
	}
	
	// 1 - Disable everything
	void Start() {
		hasSpawn = false;
		
		// Disable everything
		// -- collider
		//collider2D.enabled = false;
		// -- Moving
		moveScript.enabled = true;
	}
	
	void Update() {
		// 2 - Check if the enemy has spawned.
		if (hasSpawn == false) {
			if (renderer.IsVisibleFrom(Camera.main)) {
				Spawn();
			}
		} else {
			// 4 - Out of the camera ? Destroy the game object.
			if (renderer.IsVisibleFrom(Camera.main) == false) {
				Destroy(gameObject);
			}
		}
	}
	
	// 3 - Activate itself.
	private void Spawn() {
		hasSpawn = true;
		
		// Enable everything
		// -- Collider
		//collider2D.enabled = true;
		// -- Moving
		moveScript.enabled = true;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		// Is this a shot?
		PlayerScript player = collider.gameObject.GetComponent<PlayerScript>();
		if (player != null) {
			player.puntuation++;
		}
	}

}