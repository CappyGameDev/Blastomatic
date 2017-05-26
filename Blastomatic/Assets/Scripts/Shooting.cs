using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Shooting : MonoBehaviour {

	public XboxController controller;
	//Identifies Bullet prefab and transform

	public Transform bulletSpawnPosition;
	public GameObject bulletPrefab;

	//Identifies Bullet Shooting Speeds

	private float shootingTimer;
	public float timeBetweenShots = 1.00f;
	public float bulletSpeed = 30;

	// Use this for initialization
	void Start () {
			shootingTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Controls bullet firing if Right trigger is pressed
		FireGun ();
	}

	private void FireGun(){

		//Controls the use of shooting bullets from the player using the Bullet Prefab
		if (XCI.GetAxis (XboxAxis.RightTrigger, controller) > 0.1f) {
			if (Time.time - shootingTimer > timeBetweenShots) {
				GameObject GO = Instantiate (bulletPrefab, bulletSpawnPosition.position, transform.rotation) as GameObject;

				GO.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);

				Destroy (GO, 3);
				shootingTimer = Time.deltaTime;

			/*GameObject GO = Instantiate (bulletPrefab, bulletSpawnPosition.position, Quaternion.identity) as GameObject;

				GO.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);*/
			}
		}
	}
}
