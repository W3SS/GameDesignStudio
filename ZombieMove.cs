using UnityEngine;
using System.Collections;

public class ZombieMove : MonoBehaviour {

	public Transform mainPlayer ;
	public float MoveSpeed = 4;
	public float MaxDist = 200;
	public float MinDist = 10;

	public float interval = 1; 
	public float nextTime = 2;

	public float JumpSpeed ;
	Rigidbody rBody;


	void Start () {
	}


	void Update () {
		transform.LookAt (mainPlayer);

		if (Vector3.Distance (transform.position, mainPlayer.position) <= MaxDist) {
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		}
	}
	void FixedUpdate(){
		//Debug.Log ("time.time"+Time.time+"nextTime"+nextTime);
		if (Time.time >= nextTime) {
			Debug.Log ("jump!");
			EnemyJump ();
			nextTime += interval;
		}

	}
	void EnemyJump(){
		
		rBody = GetComponent<Rigidbody> ();
		rBody.AddForce(Vector3.up *JumpSpeed);
	}
}
