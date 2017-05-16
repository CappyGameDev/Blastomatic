using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Stores Max/min movement speeds

	public float runSpeed = 10;
	public float maxRunSpeed = 15;
	public float minRunSpeed = 5;
	public float hitPoints = 3;
	public float speed = 5;

	//Stored info on where the player spawns

	public Quaternion startingRotation;
	public Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		startingRotation = transform.rotation;
		startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {


		 //Specifies The "Left & Right" Speed
		float lrSpeed =  speed * Input.GetAxis ("Controller Horizontal");
		//Specifies the "Up & Down" Speed
		float udSpeed =  speed * Input.GetAxis ("Vertical");

		float finalSpeed;

		if (Input.GetButton ("Jump")) {
			speed = speed + runSpeed;

			if (speed > maxRunSpeed) {
				speed = maxRunSpeed;
			}
		} else {
			speed = speed - runSpeed; {

				if (speed < minRunSpeed);
				speed = minRunSpeed;
			}
			}
		}
	}
