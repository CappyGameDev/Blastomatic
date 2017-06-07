using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {

	[HideInInspector]
	//Links the Game Controller to the Player Controller
	public GameObject gameManager;

	//Links the Pink&Blue Lights to the Player Controller
	public GameObject pinkLight;
	public GameObject yellowLight;

	//Identifies Controller Support
	private Rigidbody rigidBody;
	public XboxController controller;

	//Invulnerability Boolean
	[HideInInspector]
	public bool invulnerable;

//	[HideInInspector]
//	public bool upgrade;

	//Identifies values for Player Health and score calculation
	public int hitPoints = 3;
	public int maxHitPoints = 3;
	public int scoreValue = 1;

	//Sets a max value for Light Intensity
	public int maxIntensity;

	//Stores Max/min movement speeds

	public float maxSpeed = 20;
	public float movementSpeed = 10;

	private float timePassed;
	private float invTime = 3;

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

		//Defines what the max intensity is for the lights
		maxIntensity = 8;

		invulnerable = false;
	}

	//Used to remember previous rotation of Player
	private Vector3 previousRotationDirection = Vector3.forward;

	// Update is called once per frame
	void Update ()
	{


		//Calculates the amount of time that invulnerability is active for players and resets it when the timePassed is greater than the set invulnerability time
		timePassed += Time.deltaTime;
		if (timePassed > invTime){
			timePassed = 0;
			invulnerable = false;
		}

		//Controls the constant rotation if player is presently rotating
		RotatePlayer ();

		//Respawns the player to origin point,Resets HP to max, Resets Light Intensity to max and gives them immunity to damage
		if (hitPoints <= 0) {
			if (this.gameObject.tag == "PinkPlayer") {
				gameManager.GetComponent<GameController>().AddScoreYellow (scoreValue);
				pinkLight.GetComponent<Light> ().intensity = maxIntensity;
				ResetPlayer ();
				hitPoints = maxHitPoints;
				invulnerable = true;
			} else if (this.gameObject.tag == "YellowPlayer") {
				gameManager.GetComponent<GameController>().AddScorePink (scoreValue);
				yellowLight.GetComponent<Light> ().intensity = maxIntensity;
				ResetPlayer ();
				hitPoints = maxHitPoints;
				invulnerable = true;
			}
		}
	}
	void FixedUpdate (){
		//Controls the constant movement of the player if the left stick is being used
		MovePlayer ();
	}

	private void MovePlayer (){

		//Runs the Movement function if the gameOver boolean is set to false, else does nothing
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
		//Runs the Rotation function if the gameOver boolean is set to false, else does nothing
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
//	void Upgrade () {
//
//		upgrade = true;
//	}
}
