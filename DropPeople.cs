using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropPeople : MonoBehaviour {

	public float dropdistance = 40;
	bool withinDistance = false;
	public Transform doctor;
	public GameObject thankobject;
	public Text dropText;
	public Text peopleSaved;
	public int peopleNumber;

	private CharacterController charController;
	private GameController gameController;

	void Awake () {
		thankobject.SetActive (false);
		charController = this.GetComponent<CharacterController> ();
		GameObject gameObject = GameObject.FindGameObjectWithTag ("GameCon");
		gameController = gameObject.GetComponent<GameController> ();
	}
	void Start(){
		peopleNumber = 0;
	}
	

	void Update () {
		checkDistance ();
		if (withinDistance && !gameController.isOver) {
			thankobject.SetActive (true);
			if (charController.peoplePicked > 0) {
				dropText.text = "Press P to drop people.";
			
				if (Input.GetKeyDown (KeyCode.P)) {
					peopleSaved.text = "You just saved " + charController.peoplePicked + "people!";
					peopleNumber += charController.peoplePicked;
					charController.peoplePicked = 0;
				}
			} else {
				dropText.text = "Please pick up some people and take them back here.";
			}
		} else {
			peopleSaved.text = "";
			dropText.text = "";
		}

	}

	void checkDistance(){
		if(Vector3.Distance (transform.position, doctor.position) <= dropdistance)
		{
			withinDistance = true;
		}else withinDistance = false;
	}
}
