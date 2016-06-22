using System;
using UnityEngine;
using System.Collections;
using PicaVoxel;
using Object = UnityEngine.Object;

public class BulletController : MonoBehaviour {

	//Rigidbody rBody;
	//public Transform shotspawn;
	//public float bulletforce;
	Transform mainPlayer;
	public float MoveSpeed;

	private Exploder exploder;
	private CollisionDetector detector;

	void Start () {

		mainPlayer= GameObject.Find ("MyCar").transform;

		/**
		rBody = GetComponent<Rigidbody> ();
		rBody.AddForce ((mainPlayer.position - transform.position)* bulletforce);
		**/
	}
	

	void Update () {
		transform.LookAt (mainPlayer);
		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		Destroy (this.gameObject, 4);

	}
	void OnTriggerEnter(Collider col){
		Debug.Log ("Trigger");
		if (col.gameObject.CompareTag ("MyCar")) {
			Debug.Log ("Trigger my car");
			Destroy (this.gameObject);
		} 

	}


}
