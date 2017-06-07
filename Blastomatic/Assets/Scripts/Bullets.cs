using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	public GameObject yellowLight;
	public GameObject pinkLight;

	public GameObject immuneYellow;
	public GameObject immunePink;

	private int takeIntensity;

	//Identifies amount of damage a player takes upon bullet collision with player collider
	public int hitPointDamage = 1;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1.5f);
		takeIntensity = 3;

		//Identifies Players for the immunity function
		immunePink = GameObject.FindGameObjectWithTag ("PinkPlayer");
		immuneYellow = GameObject.FindGameObjectWithTag ("YellowPlayer");

		//Identifies Lights on Players
		yellowLight = GameObject.FindGameObjectWithTag ("Blue Light");
		pinkLight = GameObject.FindGameObjectWithTag ("Pink Light");
	}
	
	// Update is called once per frame

	//Causes the bullet to damage Blue player by 1 hit point when a bullet collides
	void OnTriggerEnter (Collider other){
		if (other.tag == "YellowPlayer") {
			if (immuneYellow.GetComponent<PlayerController> ().invulnerable == true) {
				Destroy (gameObject);

			} else {
				other.GetComponent<PlayerController> ().TakeDamage (hitPointDamage);
				yellowLight.GetComponent<Light> ().intensity -= takeIntensity;
				Destroy (gameObject);
			}
		}
	//Causes the bullet to damage Pink player by 1 hit point when a bullet collides
		if (other.tag == "PinkPlayer") {
			if (immunePink.GetComponent<PlayerController> ().invulnerable == true) {
				Destroy (gameObject);
			
			} else {
				other.GetComponent<PlayerController> ().TakeDamage (hitPointDamage);
				pinkLight.GetComponent<Light> ().intensity -= takeIntensity;
				Destroy (gameObject);
			}
		}
		//Deletes the bullet when it hits a wall
			if (other.tag == "Walls") {
				Destroy (gameObject);
			}
		}
	}
