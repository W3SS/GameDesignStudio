using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

	public float starttime;
	public float endtime;
	public Text text;

	void Awake(){
		text = this.gameObject.GetComponent<Text> ();
	}

	void Start () {
		starttime = 0;
		endtime = 3;
	}

	void Update () {
		
		if (Time.time > starttime && Time.time <= endtime) {
			Debug.Log (Time.time);
			text.text = "Breaking news: The city is under servere attack. Evacuate now!";
		}
		if (Time.time > endtime) {
			text.text = "I need to help them!";
		}
	}
}
