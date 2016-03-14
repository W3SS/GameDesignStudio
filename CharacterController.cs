using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float inputDelay = 0.1f;
	public float forwardVel = 12;
	public float rotateVel = 100;
	public int speedChange = 2;

	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput;
	bool shiftSpeed = false;

	void setGravity(){
		Physics.gravity = new Vector3(0, -100.0F, 0);
	}

	public Quaternion TargetRotation
	{
		get { return TargetRotation; }
	}

	void Start()
	{
		setGravity ();
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody> ())
			rBody = GetComponent<Rigidbody> ();
		else
			Debug.LogError ("The character needs a rigidbody.");
			
	}

	void GetInput()
	{
		forwardInput = Input.GetAxis ("Vertical");		//-1~1
		turnInput = Input.GetAxis ("Horizontal");
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (shiftSpeed) {
				shiftSpeed = false;
			} else {
				shiftSpeed = true;
			}
		}
		
	}

	void Update()
	{
		GetInput ();
		Turn ();
	}

	void FixedUpdate()
	{
		Run ();
		rBody.AddForce(Vector3.zero);
	}

	void Run() 
	{
		if (Mathf.Abs (forwardInput) > inputDelay) {
			if (shiftSpeed) {
				rBody.velocity = transform.forward * forwardInput * forwardVel * speedChange;
			} else {
				rBody.velocity = transform.forward * forwardInput * forwardVel;
			}
		} else
			rBody.velocity = Vector3.zero;
	}

	void Turn()
	{
		if (Mathf.Abs (turnInput) > inputDelay) {
			
			targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;
	}
}

