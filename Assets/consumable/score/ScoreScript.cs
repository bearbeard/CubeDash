using UnityEngine;

public class ScoreScript : MonoBehaviour {

	[SerializeField] private Vector3 _rotationAmount;

	private void Start() {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
	}

	void Update() {
		transform.Rotate(_rotationAmount * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other) {
		PlayerScript.IncreaseScore(1);
		gameObject.SetActive(false);
	}

	private void GameStart() {
		if (!gameObject.activeSelf) {
			gameObject.SetActive(true);
		}
	}

	private void GameOver() {
		
	}
}
