using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

	[SerializeField] private Vector3 rotationAmount;

	void Start () {
		
	}

	void Update() {
		transform.Rotate(rotationAmount * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other) {
		gameObject.SetActive(false);
	}
}
