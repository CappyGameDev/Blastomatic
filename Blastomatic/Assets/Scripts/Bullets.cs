using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	//Identifies amount of damage a player takes upon bullet collision with player collider
	public int hitPointDamage = 1;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1.5f);
	}
	
	// Update is called once per frame

	//Causes the bullet to damage Blue player by 1 hit point when a bullet collides
	void OnTriggerEnter (Collider other){
		if (other.tag == "BluePlayer") {
			other.GetComponent<PlayerController> ().TakeDamage (hitPointDamage);
			Destroy (this.gameObject);
		}
	//Causes the bullet to damage Pink player by 1 hit point when a bullet collides
		if (other.tag == "PinkPlayer") {
			other.GetComponent<PlayerController> ().TakeDamage (hitPointDamage);
			Destroy (this.gameObject);
		}
		//Deletes the bullet when it hits a wall
			else if (other.tag == "Walls") {
				Destroy (this.gameObject);
			}
		}
	}
