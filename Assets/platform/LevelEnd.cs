﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			GameEventManager.TriggerGameOver();
		}
	}
}
