using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	[SerializeField] private Vector3 rotationAmount;

	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
	}
	
	void Update () {
		transform.Rotate(rotationAmount * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other) {
		GameEventManager.TriggerGameOver();
	}

	private void GameStart() {
		
	}

	private void GameOver() {
		gameObject.SetActive(false);
	}
}
