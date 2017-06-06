using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	public GameObject blueLight;
	public GameObject pinkLight;

	public GameObject immuneBlue;
	public GameObject immunePink;

	private int takeIntensity;

	//Identifies amount of damage a player takes upon bullet collision with player collider
	public int hitPointDamage = 1;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1.5f);
		takeIntensity = 3;

		immunePink = GameObject.FindGameObjectWithTag ("PinkPlayer");
		immuneBlue = GameObject.FindGameObjectWithTag ("BluePlayer");

		blueLight = GameObject.FindGameObjectWithTag ("Blue Light");
		pinkLight = GameObject.FindGameObjectWithTag ("Pink Light");
	}
	
	// Update is called once per frame

	//Causes the bullet to damage Blue player by 1 hit point when a bullet collides
	void OnTriggerEnter (Collider other){
		if (other.tag == "BluePlayer") {
			if (immunePink.GetComponent<PlayerController> ().invulnerable == true) {
				Destroy (this.gameObject);

			} else {
				other.GetComponent<PlayerController> ().TakeDamage (hitPointDamage);
				blueLight.GetComponent<Light> ().intensity -= takeIntensity;
				Destroy (this.gameObject);
			}
		}
	//Causes the bullet to damage Pink player by 1 hit point when a bullet collides
		if (other.tag == "PinkPlayer") {
			if (immunePink.GetComponent<PlayerController> ().invulnerable == true) {
				Destroy (this.gameObject);
			
			} else {
				other.GetComponent<PlayerController> ().TakeDamage (hitPointDamage);
				pinkLight.GetComponent<Light> ().intensity -= takeIntensity;
				Destroy (this.gameObject);
			}
		}
		//Deletes the bullet when it hits a wall
			if (other.tag == "Walls") {
				Destroy (this.gameObject);
			}
		}
	}
