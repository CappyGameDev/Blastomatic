using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	public int hitPointDamage = 1;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other){
		if (other.tag == "BluePlayer") {
			other.GetComponent<PlayerController> ().TakeDamage (hitPointDamage);
			Destroy (this.gameObject);
		}
		if (other.tag == "PinkPlayer") {
			other.GetComponent<PlayerController> ().TakeDamage (hitPointDamage);
			Destroy (this.gameObject);
		}
			else if (other.tag == "Walls") {
				Destroy (this.gameObject);
			}
		}
	}
