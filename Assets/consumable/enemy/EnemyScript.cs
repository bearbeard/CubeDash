using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	[SerializeField] private Vector3 _rotationAmount;

	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
	}
	
	void Update () {
		transform.Rotate(_rotationAmount * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other) {
		GameEventManager.TriggerGameOver();
	}

	private void GameStart() {
		gameObject.SetActive(true);
	}

	private void GameOver() {
		gameObject.SetActive(false);
	}
}
