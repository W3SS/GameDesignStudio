using UnityEngine;
using System.Collections;

public class CarColWithBuildings : MonoBehaviour {
	Rigidbody rBody;

	void OnCollisionEnter(Collision col){
		rBody = GetComponent<Rigidbody> ();
		if (col.gameObject.CompareTag ("MyCar")) {
			rBody.isKinematic = true;
		}
	}
	void OnCollisionExit(Collision col){
		rBody = GetComponent<Rigidbody> ();
		if (col.gameObject.CompareTag ("MyCar")){
			rBody.isKinematic = false;
		}
	}
}
