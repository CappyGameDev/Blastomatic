using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickups : MonoBehaviour {

	//Values for the time between When the object is destroyed and when it spawns
	private float timeTillRespawn;
	private float maxRespawn = 5;

	//Specifies the Prefab and Spawning position/Rotation of the Weapon Pickup Prefab
	public Transform upgradeSpawnPosition;
	public GameObject upgradeSpawn;

	//Used to descide whether the timer for respawning the weapon upgrade should be used or not
	private bool upgraded;

	void Start () {
		upgraded = false;
	}

	void Update () {

		//A timer to respawn the Weapon Pickup object BROKEN, MUST FIX
		if (upgraded == true){
			Debug.Log ("Timer Started");
		timeTillRespawn += Time.deltaTime;
		if (timeTillRespawn > maxRespawn){
			timeTillRespawn = 0;
				GetComponent<BoxCollider> ().enabled = true;
				GetComponent<MeshRenderer> ().enabled = true;
				upgraded = false;
		}
	}
}

	//Used to Destroy the weapon pickup Prefab and set the public boolean in the Shooting script "upgradePink" or "upgradeYellow" to true.
	void OnTriggerEnter (Collider other) {

		if (other.tag == "PinkPlayer") {
			other.GetComponent <Shooting> ().upgradePink = true;
			upgraded = true;
			GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<BoxCollider> ().enabled = false;
		}
		if (other.tag == "YellowPlayer") {
			other.GetComponent <Shooting> ().upgradeYellow = true;
			upgraded = true;
			GetComponent<BoxCollider> ().enabled = false;
			GetComponent<MeshRenderer> ().enabled = false;
		}
	}
}
