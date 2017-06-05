using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	//Used to identify visual representations of blue/pink kills
	public GUIText blueText;
	public GUIText pinkText;

	//Integers to calculate kills between blue/pink scores, and sets a maximum kill count
	private int pinkScore;
	private int blueScore;
	private int maxScore;

	//Sets base gameplay values as if it were a new game
	void Start () {
		pinkText.text = "";
		blueText.text = "";
		blueScore = 0;
		pinkScore = 0;
		maxScore = 10;
		UpdateScore ();
	}


	void Update () {
		// Forces the entire scene to reload if the 'R' key is pressed whilst game is running
			if (Input.GetKeyDown (KeyCode.R)) {

				Application.LoadLevel (Application.loadedLevelName);
			}
		}

	//Increases pink kills by 1 when pink player kills blue player
	public void AddScorePink (int newScoreValue) {

		pinkScore += newScoreValue;
		UpdateScore ();

	}

	//Updates the GUI Text when a player gets a kill
	void UpdateScore () {

		pinkText.text = "Pink Kills: " + pinkScore;
		blueText.text = "Blue Kills: " + blueScore;

		BlueGameOver ();
	}

	// Increases blue kills by 1 when blue player kills pink player
	public void AddScoreBlue (int newScoreValue) {

		blueScore += newScoreValue;
		UpdateScore ();

	}

	public void BlueGameOver () {

		if (blueScore == maxScore) {

			Debug.Log("Game Over");

		}
	}
}