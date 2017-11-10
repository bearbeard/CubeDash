using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	private static int _score;
	
	private Vector3 _startPosition;

	[SerializeField] private float _speed;
	[SerializeField] private Vector3 _boostAmount;
	[SerializeField] private Vector3 _jumpAmount;
	[SerializeField] private Text _scoreText;

	private Rigidbody _rigidbody;
	private MeshRenderer _meshRenderer;
	private bool _isGrounded;
	private bool _canBoost;

	private void Awake() {
		Physics.gravity = new Vector3(0f, -25f, 0f);
		_rigidbody = GetComponent<Rigidbody>();
		_meshRenderer = GetComponent<MeshRenderer>();
		_score = 0;
	}

	void Start() {
		_startPosition = transform.localPosition;
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		_rigidbody.isKinematic = true;
		_meshRenderer.enabled = false;
		enabled = false;
	}

	void Update() {
		CheckIsFallenDown();
		Jump();
		_scoreText.text = _score.ToString();
		Debug.Log(_rigidbody.velocity);
	}

	private void FixedUpdate() {
		_rigidbody.AddForce(Vector3.right * _speed - _rigidbody.velocity, ForceMode.Acceleration);
		//Jump();
	}

	private void Jump() {
		if (Input.GetButtonDown("Jump")) {
			if (_isGrounded) {
				_rigidbody.AddForce(_jumpAmount, ForceMode.Impulse);
			} else if (_canBoost) {
				_rigidbody.AddForce(_boostAmount, ForceMode.VelocityChange);
				_canBoost = false;
			}
		}
		if (Input.GetButton("Jump")) {
			Vector3 jumpAddition = new Vector3(0f, 1000f, 0f);
			jumpAddition *= Time.deltaTime;
			_rigidbody.AddForce(jumpAddition, ForceMode.Acceleration);
		}
	}

	private void CheckIsFallenDown() {
		if (transform.position.y < -5f) {
			GameEventManager.TriggerGameOver();
		}
	}

	private void GameStart() {
		transform.localPosition = _startPosition;
		_rigidbody.isKinematic = false;
		_meshRenderer.enabled = true;
		enabled = true;
	}

	private void GameOver() {
		_rigidbody.isKinematic = true;
		_meshRenderer.enabled = false;
		enabled = false;
	}

	private void OnCollisionEnter(Collision collision) {
		_isGrounded = true;
		_canBoost = false;
	}

	private void OnCollisionExit(Collision collision) {
		_isGrounded = false;
		_canBoost = true;
	}

	public static void IncreaseScore(int amount) {
		_score += amount;
	}
}
