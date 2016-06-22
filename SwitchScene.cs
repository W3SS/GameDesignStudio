using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("secondScene")) {
			SceneManager.LoadScene ("2ndScene", LoadSceneMode.Single);
		}
	}
}
