using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
		
	public GUIText scoreText;

	private int score;

	void Start () {
		scoreText.text = "0";
		score = 0;
		UpdateScore ();
	}
	void Update () {

		if (Input.GetKeyDown (KeyCode.R)) {

			Application.LoadLevel (Application.loadedLevelName);
		}
	}

	public void AddScore (int newScoreValue) {

		score += newScoreValue;
		UpdateScore ();

	}
	void UpdateScore () {

		scoreText.text = "Score: " + score;
	}
}