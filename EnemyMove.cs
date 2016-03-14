using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public Transform mainPlayer = GameObject.Find ("Main1").transform;
	public float MoveSpeed = 4;
	public float MaxDist = 200;
	public float MinDist = 10;

	public float interval = 1; 
	public float nextTime = 2;
	public float intervalBullet = 1; 
	public float nextTimeBullet = 2;

	public float JumpSpeed ;
	Rigidbody rBody;

	public GameObject shot;
	public Transform shotSpawn;


	void Start () {
		//mainPlayer = GameObject.Find ("Main1").transform;
	}
	

	void Update () {
		transform.LookAt (mainPlayer);

		if (Vector3.Distance (transform.position, mainPlayer.position) >= MinDist) {
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
			if (Vector3.Distance (transform.position, mainPlayer.position) <= MaxDist) {
				//Gameobject bullet = 

				//as GameObject;
			}
		}
	}
	void FixedUpdate(){
		if (Time.time >= nextTime) {
			EnemyJump ();
			nextTime += interval;
		}
		if (Time.time >= nextTimeBullet) {
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation) ;
			nextTimeBullet += intervalBullet;
		}
		//InvokeRepeating("EnemyJump", 0, 1.0F);
	}
	void EnemyJump(){
		rBody = GetComponent<Rigidbody> ();
		rBody.AddForce(Vector3.up *JumpSpeed);
	}
}
