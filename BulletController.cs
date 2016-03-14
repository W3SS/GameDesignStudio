using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	Rigidbody rBody;
	public Transform shotspawn;
	public float bulletforce;
	Transform mainPlayer;

	void Start () {
		//Vector3 Rrotation;
		//v3 = shotspawn.rotation.eulerAngles;
		mainPlayer= GameObject.Find ("Main1").transform;
		rBody = GetComponent<Rigidbody> ();
		rBody.AddForce ((mainPlayer.position - transform.position)* bulletforce);
	}
	

	void Update () {
		if (Time.time >= 5) {
			Destroy (gameObject);
		}
	}
	/**
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "ground") {
			Debug.LogError ("collision with ground");
			Destroy (this.gameObject);
		}
	}
	**/

}
