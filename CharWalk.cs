using UnityEngine;
using System.Collections;
using UnityEngine.UI;
	
public class CharWalk : MonoBehaviour {

	public float MoveSpeed = 10;
	public float WalkSpeed = 5;
	public Transform mainPlayer;
	Rigidbody rBody;

	public float patrolRange = 40;
	public float getCarRange = 20;
	bool playerIsNearby;

	public float interval = 1; 
	public float nextTime = 2;

	private CharacterController charController;
	private GameController gameController;
	private PlayerHealth playerHealth;
	public bool isAddTime;
	public Text peopleText;



	void Awake(){
		mainPlayer =  GameObject.FindGameObjectWithTag ("MyCar").transform;
		GameObject charObject = GameObject.FindGameObjectWithTag ("MyCar");
		GameObject uiObject = GameObject.FindGameObjectWithTag ("displayPeople");

		if (uiObject != null) {
			peopleText = uiObject.GetComponent<Text> ();
		} else Debug.Log ("Cannot find 'peoplePicked UI object'");
		if (charObject != null) {
			charController = charObject.GetComponent<CharacterController> ();

		} else Debug.Log ("Cannot find 'charController' object");

		GameObject gameObject = GameObject.FindGameObjectWithTag ("GameCon");
		gameController = gameObject.GetComponent<GameController> ();

		playerHealth = charObject.GetComponent<PlayerHealth> ();

	
	}

	void Start(){
		isAddTime = false;
	}

	void Update()
	{	
		
		if (!gameController.isOver) {
		
			if (charController.peoplePicked < 4) {
				if (charController.peoplePicked == 0)
					peopleText.text = "You haven't saved anyone! yet";
				else
					peopleText.text = "You have picked up " + charController.peoplePicked + " people.";
				checkMain ();
				if (playerIsNearby) {
					//Debug.LogError ("close enough");
					transform.LookAt (mainPlayer);
					transform.position += transform.forward * MoveSpeed * Time.deltaTime;
				} 
				if (checkEnter ()) {
					if (this.gameObject.tag == "AddTime") {
						isAddTime = true;

					} else if (this.gameObject.tag == "AddHealth") {
						playerHealth.TakeDamage (-20);
						//Debug.Log (playerHealth.currentHealth);
					}
					Destroy (this.gameObject);
					charController.peoplePicked++;
				}
			} else {
				peopleText.text = "Your car is full. Go to the hospital now!";
			}
		} else {
			peopleText.text = "";
		}
	}

	void checkMain() {
		if (Vector3.Distance (transform.position, mainPlayer.position) <= patrolRange)	
			playerIsNearby = true;
		else
			playerIsNearby = false;
	}

	bool checkEnter() {
		//Debug.LogError (Vector3.Distance (transform.position, mainPlayer.position));
		if (Vector3.Distance (transform.position, mainPlayer.position) <= getCarRange)	
			return true;
		else
			return false;
	}

	void randomWalk (){
		/**
		float turnInput = Random.value;
		walkRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = walkRotation;
		**/
		transform.Rotate(0, Random.Range(0,360), 0);
		//Debug.LogError ("turned"+turnInput);
	}

	void FixedUpdate(){
		if (!playerIsNearby) {
			if (Time.time >= nextTime) {
				randomWalk();
				nextTime += interval;
			}
			transform.position += transform.forward * WalkSpeed * Time.deltaTime;
		}
		
	}
}
