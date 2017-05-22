using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {

	//Identifies Controller Support
	private Rigidbody rigidBody;
	public XboxController controller;

	//Stores Max/min movement speeds

	public float maxSpeed = 60;
	public float movementSpeed = 10;

	//Stored info on where the player spawns

	public Quaternion startingRotation;
	public Vector3 startingPosition;

	//Identifies the player hit points

	public float hitPoints = 3;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	//Used to remember previous rotation of Player
	private Vector3 previousRotationDirection = Vector3.forward;

	// Update is called once per frame
	void Update ()
	{
		//Controls the constant rotation if player is presently rotating
		RotatePlayer ();
	}
	void FixedUpdate (){
		//Controls the constant movement of the player if the left stick is being used
		MovePlayer ();
	}

	private void MovePlayer (){
		
		//Allows for 360 Degrees rotation on the Left Stick on X & Z Axis'
		float axisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis(XboxAxis.LeftStickY, controller);

		Vector3 movement = new Vector3 (axisX, 0, axisZ);

		rigidBody.AddForce (movement * movementSpeed);

		//Makes sure the player cannot go faster than the max Speed

		if (rigidBody.velocity.magnitude > maxSpeed) {
			rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
		}
	}

	private void RotatePlayer ()
	{

		//Allows for 360 Degrees rotation on the Right Stick on X & Y Axis'
		float rotateAxisX = XCI.GetAxis (XboxAxis.RightStickX, controller);
		float rotateAxisZ = XCI.GetAxis (XboxAxis.RightStickY, controller);

		Vector3 directionVector = new Vector3 (rotateAxisX, 0, rotateAxisZ);

		//Checks to see if the Right stick is being used. If not, player will remain in current rotation
		if (directionVector.magnitude < 0.1f) {
			directionVector = previousRotationDirection;
		}

		directionVector = directionVector.normalized;
		previousRotationDirection = directionVector;
		transform.rotation = Quaternion.LookRotation (directionVector);

	}

}
