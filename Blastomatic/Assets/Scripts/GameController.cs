using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//Used to identify visual representations of blue/pink kills
	public Text yellowText;
	public Text pinkText;
	public Text gameOverYellow;
	public Text gameOverPink;
	public Text restartYellow;
	public Text restartPink;

	//Integers to calculate kills between blue/pink scores, and sets a maximum kill count
	private int pinkScore;
	private int yellowScore;
	private int maxScore;

	//Used to specify whether the game has ended or not
	[HideInInspector]
	public bool gameOver;

	//Links the Blue & Pink Players to the Game Controller
	public GameObject yellowPlayer;
	public GameObject pinkPlayer;

	//Sets base gameplay values as if it were a new game
	void Start () {
		pinkText.text = "";
		yellowText.text = "";
		yellowScore = 0;
		pinkScore = 0;
		maxScore = 5;
		UpdateScore ();
		gameOver = false;
		gameOverYellow.text = "";
		gameOverPink.text = "";
		restartYellow.text = "";
		restartPink.text = "";
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

	// Increases blue kills by 1 when blue player kills pink player
	public void AddScoreYellow (int newScoreValue) {

		yellowScore += newScoreValue;
		UpdateScore ();

	}

	//Updates the GUI Text when a player gets a kill
	void UpdateScore () {

		pinkText.text = "Pink Kills: " + pinkScore;
		yellowText.text = "Yellow Kills: " + yellowScore;

		YellowGameOver ();
		PinkGameOver ();
	}
		
	//Displays the Game Over Text indicating Yellow Win when game ends
	public void YellowGameOver () {

		if (yellowScore == maxScore) {
			gameOverYellow.text = "Game Over, Yellow Player Wins!";
			restartYellow.text = "Press R to play again";
			Debug.Log("Game Over, Yellow Player Wins");
			gameOver = true;
		}
	}

	//Displays Game Over Text indicating Pink Win when game ends
	public void PinkGameOver () {

		if (pinkScore == maxScore) {
			gameOverPink.text = "Game Over, Pink Player Wins!";
			restartPink.text = "Press R to play again";
			Debug.Log("Game Over, Pink Player Wins");
			gameOver = true;
		}
	}
}