using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	/// <summary>
	/// Total hitpoints
	/// </summary>
	public float hp = 100;

	public float damage = 25;
	
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;

	void start(){

	}

	void update() {

	}

	void OnCollisionEnter2D(Collision2D collider) {
		
		// Is this a shot?
		HealthScript enemy = collider.gameObject.GetComponent<HealthScript>();
		if (enemy != null) {

			if (enemy.isEnemy) {
				hp -= enemy.damage;
				
				// Destroy the shot
				// Remember to always target the game object,
				// otherwise you will just remove the script.
				Destroy(enemy.gameObject);
				
				if (hp <= 0) {
					//Dead!
					handlePlayerDeath();

				}
			}
		}
	}

	void handlePlayerDeath() {
		// Dead!
		Debug.Log ("Dead!!!");

		Time.timeScale = 0f;

		EndGame endgame = gameObject.GetComponent<EndGame> ();
		endgame.enabled = true;
		//Destroy(gameObject);
	}

}
