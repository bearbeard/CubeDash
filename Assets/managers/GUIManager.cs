using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
	[SerializeField] private Text _gameOverText;
	[SerializeField] private Text _restartText;
	[SerializeField] private Text _titleText;
	[SerializeField] private Text _starText;

	private void Awake() {
		_gameOverText.enabled = false;
		_restartText.enabled = false;
		_titleText.enabled = true;
		_starText.enabled = true;
	}

	void Start() {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
	}

	void Update() {
		if (Input.GetButtonDown("Jump")) {
			GameEventManager.TriggerGameStart();
		}
	}

	private void GameStart() {
		_restartText.enabled = false;
		_gameOverText.enabled = false;
		_titleText.enabled = false;
		_starText.enabled = false;
		enabled = false;
	}

	private void GameOver() {
		_restartText.enabled = true;
		_gameOverText.enabled = true;
		enabled = true;
	}
}