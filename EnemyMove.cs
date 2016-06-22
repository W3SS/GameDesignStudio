using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public Transform mainPlayer;
	public float MoveSpeed = 4;
	public float WalkSpeed = 1;
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
	bool detectPlayer;

	void Awake(){
		mainPlayer = GameObject.Find ("MyCar").transform;
	}

	void Start () {
		//mainPlayer = GameObject.Find ("Main1").transform;
	}
	

	void Update () {
		
		detectPlayer =(Vector3.Distance (transform.position, mainPlayer.position) <= MaxDist);
		if (detectPlayer) {
			transform.LookAt (mainPlayer);
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		} 
	}

	void FixedUpdate(){
		if (Time.time >= nextTime) {
			if (!detectPlayer) {
				transform.Rotate (0, Random.Range (0, 360), 0);
				
			
				nextTime += interval;
			}
			transform.position += transform.forward * WalkSpeed * Time.deltaTime;
		}
		if (Time.time >= nextTimeBullet) {
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			nextTimeBullet += intervalBullet;
		}

	}
		
}
