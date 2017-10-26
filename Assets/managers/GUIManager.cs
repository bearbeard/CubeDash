using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {

	void Start () {
		GameEventManager.GameStart = GameStart;
		GameEventManager.GameOver = GameOver;
	}
	
	void Update () {
		if (Input.GetButtonDown("Jump")) {
			GameEventManager.TriggerGameStart();
		}
	}

	private void GameStart() {
		Debug.Log("GUIManager");
		enabled = false;
	}

	private void GameOver() {
		enabled = true;
	}
}
