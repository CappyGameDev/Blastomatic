using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {

	//Links the Game Controller to the Player Controller
	public GameObject gameManager;

	//Identifies Controller Support
	private Rigidbody rigidBody;
	public XboxController controller;

	//Identifies values for Player Health and score calculation
	public int hitPoints = 5;
	public int maxHitPoints = 5;
	public int scoreValue = 1;

	//Stores Max/min movement speeds

	public float maxSpeed = 20;
	public float movementSpeed = 10;

	//Stored info on where the player spawns

	public Quaternion startingRotation;
	public Vector3 startingPosition;

	//Used to calculate damage
	public void TakeDamage(int damageToTake) {
		hitPoints = hitPoints - damageToTake;
	}
		
	// Use this for initialization
	void Start () {

		//References the Game Controller Script
		gameManager = GameObject.FindGameObjectWithTag ("GameController");

		//Used to identify the Rigidbody on Players
		rigidBody = GetComponent<Rigidbody> ();

		//Assigns a starting position for the Players
		startingRotation = transform.rotation;
		startingPosition = transform.position;
	}

	//Used to remember previous rotation of Player
	private Vector3 previousRotationDirection = Vector3.forward;

	// Update is called once per frame
	void Update ()
	{
		//Controls the constant rotation if player is presently rotating
		RotatePlayer ();

		if (hitPoints <= 0) {
			if (this.gameObject.tag == "PinkPlayer") {
				gameManager.GetComponent<GameController>().AddScoreBlue (scoreValue);
				ResetPlayer ();
				hitPoints = maxHitPoints;
			} else if (this.gameObject.tag == "BluePlayer") {
				gameManager.GetComponent<GameController>().AddScorePink (scoreValue);
				ResetPlayer ();
				hitPoints = maxHitPoints;
			}
		}
	}
	void FixedUpdate (){
		//Controls the constant movement of the player if the left stick is being used
		MovePlayer ();
	}

	private void MovePlayer (){

		if (gameManager.GetComponent<GameController> ().gameOver == false) {
			//Allows for 360 Degrees rotation on the Left Stick on X & Z Axis'
			float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
			float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);

			Vector3 movement = new Vector3 (axisX, 0, axisZ);

			rigidBody.AddForce (movement * movementSpeed);
			//Makes sure the player cannot go faster than the max Speed

			if (rigidBody.velocity.magnitude > maxSpeed) {
				rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
			}
		}
	}
	private void RotatePlayer ()
	{
		if (gameManager.GetComponent<GameController> ().gameOver == false) {
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

	//Used to reset player position to spawn upon 'death'
	void ResetPlayer ()
	{
		transform.position = startingPosition;
		transform.rotation = startingRotation;
		GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
}
