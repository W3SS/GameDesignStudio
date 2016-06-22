using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	//public PlayerHealth playerHealth;
	public GameObject enemy;

	public Transform[] spawnPoints;
	public int enemyNumber ;
	public float interval ; 
	public float nextTime ;
	public int enemyNum = 0;

	void Start(){

		//InvokeRepeating ("Spawn", spawnTime, spawnTime);

	}

	void FixedUpdate(){

		if (Time.time >= nextTime) {
			if (enemyNum <= enemyNumber) {
				Spawn ();
				enemyNum++;
			}
			nextTime += interval;
		}

	}

	void Spawn (){
		/**
		if (playerHealth.currentHealth <= 0f) {
			return;
		}
		**/

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

	Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);

	}
}
