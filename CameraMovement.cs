using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		if(player != null)
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null)
		transform.position = player.transform.position + offset;
	}
}
