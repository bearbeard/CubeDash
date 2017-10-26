using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public Vector3 startPosition;

	[SerializeField] private float speed;
	[SerializeField] private Vector3 boostAmount;
	[SerializeField] private Vector3 jumpAmount;

	private Rigidbody rigidbody;
	private MeshRenderer meshRenderer;
	private bool isGrounded;
	private bool canBoost;
	private float xVelocity = 0f;
	private float yVelocity = 0f;

	private void Awake() {
		rigidbody = GetComponent<Rigidbody>();
		meshRenderer = GetComponent<MeshRenderer>();
	}

	void Start () {
		startPosition = transform.localPosition;
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		rigidbody.isKinematic = true;
		meshRenderer.enabled = false;
		enabled = false;
	}
	
	void Update () {
		Debug.Log(transform.position);	
		Move();
	}

	private void FixedUpdate() {
		rigidbody.AddForce(Vector3.right * speed - rigidbody.velocity, ForceMode.Acceleration);
	}

	private void Move() {
		if (Input.GetButtonDown("Jump")) {
			if (isGrounded) {
				rigidbody.AddForce(jumpAmount, ForceMode.VelocityChange);			
			} else if (canBoost) {
				rigidbody.AddForce(boostAmount, ForceMode.VelocityChange);
				canBoost = false;
			}			
		}
	}

	private void GameStart() {
		Debug.Log("PlayerScript");
		transform.localPosition = startPosition;
		rigidbody.isKinematic = false;
		meshRenderer.enabled = true;
		enabled = true;
	}

	private void GameOver() {
		rigidbody.isKinematic = true;
		meshRenderer.enabled = false;
		enabled = false;
	}

	private void OnCollisionEnter(Collision collision) {
		isGrounded = true;
		canBoost = false;
	}

	private void OnCollisionExit(Collision collision) {
		isGrounded = false;
		canBoost = true;
	}

	private void OnCollisionStay(Collision collision) {

	}


}
