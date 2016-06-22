using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;

	private globaltimer gt;
	private DropPeople dropPeople;

	public bool isOver;

	void Awake(){

		GameObject dropObject = GameObject.FindGameObjectWithTag ("MyCar");
		dropPeople = dropObject.GetComponent<DropPeople> ();

		GameObject gtObject = GameObject.FindGameObjectWithTag ("TimeLeft");
		if (gtObject != null)
		{
			gt = gtObject.GetComponent <globaltimer>();
		}
		if (gtObject == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	void Start ()
	{
		
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		isOver = false;
		//score = 0;
		//UpdateScore ();
		//StartCoroutine (SpawnWaves ());
	}
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene ("2ndScene", LoadSceneMode.Single);
			}
		}
		if (gt.timeLeft <= 0) {
			GameOver ();
		}
		if (gameOver)
		{
			dropPeople.dropText.text = "";
			dropPeople.peopleSaved.text = "";
			restartText.text = "Press 'R' for Restart";
			restart = true;
		}
	}

	public void GameOver ()
	{
		isOver = true;
		gameOverText.text = "Game Over! You've saved " + dropPeople.peopleNumber + " people!";
		gameOver = true;

	}
}
