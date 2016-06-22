using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PicaVoxel;

public class SwitchCharacter : MonoBehaviour {

	GameObject[] gameobjects;

	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag.Equals("MyCar") == true) {
			//
			Destroy (this.gameObject);
			other.gameObject.GetComponent<CharacterController> ().enabled = true;
			other.gameObject.GetComponent<BasicAnimator1> ().enabled = true;
			gameobjects = GameObject.FindGameObjectsWithTag("CarLight");
			foreach (GameObject light in gameobjects) {
				light.GetComponent<Light> ().enabled = true;
			}
		}
	}
}
