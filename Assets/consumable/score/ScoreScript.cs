using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

	[SerializeField] private Vector3 _rotationAmount;

	void Update() {
		transform.Rotate(_rotationAmount * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other) {
		PlayerScript.IncreaseScore(1);
		gameObject.SetActive(false);
	}
}
