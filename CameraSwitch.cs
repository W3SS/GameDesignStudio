using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	//public Camera startCam;
	public Camera mainCam;
	public Camera secondCam;
	public GameObject gameobject;


	void Start(){
		//startCam.enabled = true;
		mainCam.enabled = true;
		secondCam.enabled = false;
	}

	void Update(){
		/**
		if (Input.GetKeyDown(KeyCode.S)) {
			startCam.enabled = false;
			secondCam.enabled = true;
		}
		**/
		if (gameobject == null) {
			secondCam.enabled = true;
			mainCam.enabled = false;
		}
	}
}
