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


	//These booleans are used to decide whether a player has picked up the weapon upgrade or not
	[HideInInspector]
	public bool upgradePink;
	[HideInInspector]
	public bool upgradeYellow;

	private float upgradeTime;
	private float maxTime = 8;


	// Use this for initialization
	void Start () {
		//Gives an identification for the time between bullet shots
		shootingTimer = Time.time;

		upgradePink = false;
		upgradeYellow = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Timer for the Weapon Upgrade
		upgradeTime += Time.deltaTime;
		if (upgradeTime > maxTime){
			upgradeTime = 0;
			upgradePink = false;
			upgradeYellow = false;
		}

		Debug.Log (upgradePink);
		Debug.Log (upgradeYellow);

		//References the FireGun & WeaponUpgrade functions constantly on update when Right Trigger is pressed/held down
		FireGun ();
		//WeaponUpgrade ();

	}

	private void FireGun(){
	
		//Fires the gun if the gameOver boolean is set to false, else does nothing
		if (gameManager.GetComponent<GameController> ().gameOver == false) {
			
		//Controls the use of shooting bullets from the player using the Bullet Prefab
		if (XCI.GetAxis (XboxAxis.RightTrigger, controller) > 0.1f) {
				if (Time.time - shootingTimer > timeBetweenShots) {
					GameObject GO = Instantiate (bulletPrefab, bulletSpawnPosition.position, transform.rotation) as GameObject;

					GO.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);

					Destroy (GO, 3);
					shootingTimer = Time.time;


					if (upgradePink == true)
					{
						//Vector3 tempRot = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y * -1, transform.eulerAngles.z);
						//Vector3 tempRot = transform.eulerAngles;

						Quaternion tempRot = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y * -1, transform.eulerAngles.z);

						GameObject GO2 = Instantiate (bulletPrefab, bulletSpawnPosition.position, tempRot) as GameObject;
						GO2.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);
						Destroy (GO2, 3);
					}

					if (upgradeYellow == true)
					{
						//Vector3 tempRot = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y * -1, transform.eulerAngles.z);
						//Vector3 tempRot = transform.eulerAngles;

						Quaternion tempRot = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y * -1, transform.eulerAngles.z);

						GameObject GO2 = Instantiate (bulletPrefab, bulletSpawnPosition.position, tempRot) as GameObject;
						GO2.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);
						Destroy (GO2, 3);
					}

					//Broken code which caused double spawning of bullets
					/*GameObject GO = Instantiate (bulletPrefab, bulletSpawnPosition.position, Quaternion.identity) as GameObject;

				GO.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);*/
				}
			}
		}
	}

//	private void WeaponUpgrade (){
//
//
//		//Fires the gun if the gameOver boolean is set to false, else does nothing
//		if (gameManager.GetComponent<GameController> ().gameOver == false) {
//
//			//Activates the Weapon Upgrade if the Pink Player collects the Weapon Pickup Object
//		}else if (upgradePink == true) {
//				//Fires a second amount of bullets 
//			if (XCI.GetAxis (XboxAxis.RightTrigger, controller) > 0.1f) {
//					if (Time.time - shootingTimer > timeBetweenShots) {
//						GameObject GO = Instantiate (bulletPrefab, upgradeSpawnPosition.position, transform.rotation) as GameObject;
//
//						GO.GetComponent<Rigidbody> ().AddForce (-transform.forward * bulletSpeed, ForceMode.Impulse);
//
//						Destroy (GO, 3);
//						shootingTimer = Time.time;
//					}
//				}
//			}
//		}
	}
