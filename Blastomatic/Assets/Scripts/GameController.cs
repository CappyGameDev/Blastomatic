using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GUIText blueText;
	public GUIText pinkText;

	private int pinkScore;
	private int blueScore;

	void Start () {
		pinkText.text = "";
		blueText.text = "";
		blueScore = 0;
		pinkScore = 0;
		UpdateScore ();
	}
	void Update () {

			if (Input.GetKeyDown (KeyCode.R)) {

				Application.LoadLevel (Application.loadedLevelName);
			}
		}

	public void AddScorePink (int newScoreValue) {

		pinkScore += newScoreValue;
		UpdateScore ();

	}
	void UpdateScore () {

		pinkText.text = "Pink Kills: " + pinkScore;
		blueText.text = "Blue Kills: " + blueScore;
	}
	public void AddScoreBlue (int newScoreValue) {

		blueScore += newScoreValue;
		UpdateScore ();

	}
}