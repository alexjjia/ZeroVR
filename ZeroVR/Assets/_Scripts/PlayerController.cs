using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Vector3 movementVector;
	private CharacterController characterController;
	public float moveSpeed = 8;
	public float jumpPower = 16;
	public float gravity = 40;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		movementVector.x = Input.GetAxis ("LeftJoystickX") * moveSpeed;
		movementVector.z = Input.GetAxis ("LeftJoystickY") * moveSpeed;

		if (characterController.isGrounded) {
			movementVector.y = 0; //resets the dood.
			if (Input.GetButtonDown ("A")) {
				movementVector.y = jumpPower;
			}
		}
		movementVector.y -= gravity * Time.deltaTime;

		characterController.Move (movementVector * Time.deltaTime);
	}
}

