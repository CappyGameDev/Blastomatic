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
		if (other.tag == "Player") {
			other.GetComponent<PlayerController> ().TakeDamage (hitPointDamage);
			Destroy (this.gameObject);
		}
	}
}
