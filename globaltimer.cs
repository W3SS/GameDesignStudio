using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class globaltimer : MonoBehaviour {

	public float timeLeft;
	Text text;
	private CharWalk cWalk;

	void Awake(){
		GameObject walkObject = GameObject.FindGameObjectWithTag ("AddTime");
		if (walkObject != null) {
			cWalk = walkObject.GetComponent<CharWalk> ();
		}
		text = GetComponent <Text> ();
	}
	void Update()
	{
		Debug.Log (cWalk.isAddTime);
		if (cWalk != null) {
			if (cWalk.isAddTime) {
				Debug.Log (timeLeft);
				timeLeft += 10;
				cWalk.isAddTime = false;
				Debug.Log (timeLeft);
			}
		}
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			text.text = "Time Left: " + (int)timeLeft;
		}
		if(timeLeft <= 0)
		{
			text.text = "Time's Up!";
		}
	}
}
