using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Shooting : MonoBehaviour {

	//Used to give a certain controller use of a player
	public XboxController controller;

	//References the Game controller Script to the Shooting Script
	public GameObject gameManager;

	//Identifies Bullet prefab and transform
	public Transform bulletSpawnPosition;
	public GameObject bulletPrefab;

	//Identifies Bullet Shooting/Movement Speeds
	private float shootingTimer;
	public float timeBetweenShots = 0.4f;
	public float bulletSpeed = 30;


	// Use this for initialization
	void Start () {
		//Gives an identification for the time between bullet shots
			shootingTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		//References the FireGun function constantly on update when Right Trigger is pressed/held down
		FireGun ();
	}

	private void FireGun(){
	
		if (gameManager.GetComponent<GameController> ().gameOver == false) {
		//Controls the use of shooting bullets from the player using the Bullet Prefab
		if (XCI.GetAxis (XboxAxis.RightTrigger, controller) > 0.1f) {
				if (Time.time - shootingTimer > timeBetweenShots) {
					GameObject GO = Instantiate (bulletPrefab, bulletSpawnPosition.position, transform.rotation) as GameObject;

					GO.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);

					Destroy (GO, 3);
					shootingTimer = Time.time;

					//Broken code which caused double spawning of bullets
					/*GameObject GO = Instantiate (bulletPrefab, bulletSpawnPosition.position, Quaternion.identity) as GameObject;

				GO.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);*/
				}
			}
		}
	}
}
