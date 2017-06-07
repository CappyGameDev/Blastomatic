using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickups : MonoBehaviour {


	private float timeTillRespawn;
	private float maxRespawn = 5;

	[HideInInspector]
	public bool upgraded;

	void Start () {
		upgraded = false;
	}

	void Update () {

		//A timer to respawn the Weapon Pickup object BROKEN, MUST FIX
		if (upgraded = true){
		timeTillRespawn += Time.deltaTime;
		if (timeTillRespawn > maxRespawn){
			timeTillRespawn = 0;
			gameObject.SetActive (true);
				upgraded = false;
		}
	}
}

	void OnTriggerEnter (Collider other) {

		if (other.tag == "PinkPlayer") {
			other.GetComponent <Shooting> ().upgradePink = true;
			gameObject.SetActive (false);
			upgraded = true;
		}
		if (other.tag == "YellowPlayer") {
			other.GetComponent <Shooting> ().upgradeYellow = true;
			gameObject.SetActive (false);
			upgraded = true;
		}
	}
}
