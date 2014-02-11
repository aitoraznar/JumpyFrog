using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public int initialEnemies = 1;

	public int numEnemy = 0;

	public GameObject scene;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		numEnemy = initialEnemies;

		for(int i = 0; i < initialEnemies; i++){
			spawnEnemy(i);
		}


		new WaitForSeconds(4f);
		StartCoroutine(CreateEnemyCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void spawnEnemy(int i){
		Debug.Log ("spawnEnemy("+i+")");
		GameObject ske1 = (GameObject)Instantiate(Resources.Load("Skeledog"));

		ske1.transform.parent = scene.transform;
		ske1.transform.position = new Vector3 (1*(i+1), -2, 0);
		MoveScript moveScript = ske1.GetComponent<MoveScript>();
		moveScript.enabled = true;
		numEnemy++;
	}

	IEnumerator CreateEnemyCoroutine() {
		while (true){
			spawnEnemy(numEnemy);
			yield return new WaitForSeconds(2f);    
		}
	}

}