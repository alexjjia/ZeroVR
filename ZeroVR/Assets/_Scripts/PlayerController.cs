using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Vector3 movementVector;
	private float verticalMove, horizontalMove, horizontalTurn;
	private CharacterController characterController;

	//test values.
	public Camera mainCamera;
//	public Camera secondaryCamera;
	public float moveSpeed = 8;
	public float turnSpeed = 6;
	public float jumpPower = 16;
	public float gravity = 9.8f;
	private bool fireLeft = false;
	private bool fireRight = false;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		mainCamera.enabled = true;
//		secondaryCamera.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		//Player Movement


		if (characterController.isGrounded) {
			movementVector.y = 0; //resets the dood.
			movementVector = transform.forward * Input.GetAxis ("LeftJoystickY") * moveSpeed;
			horizontalTurn = Input.GetAxis ("RightJoystickX") * turnSpeed;

			transform.Rotate (new Vector3 (0, horizontalTurn, 0));
			if (Input.GetButtonDown ("A")) {
				movementVector.y = jumpPower;
			}
		}
		movementVector.y -= gravity * Time.deltaTime;
		characterController.Move(movementVector * Time.deltaTime);
	

	//	movementVector.x = Input.GetAxis ("LeftJoystickX") * moveSpeed;
	//	movementVector.z = Input.GetAxis ("LeftJoystickY") * moveSpeed;


	//	characterController.Move (movementVector * Time.deltaTime);

		if (Input.GetAxis ("LeftTrigger") > 0) {
			fireLeft = true;
			Debug.Log ("fireLeft: " + fireLeft);
		} 
		if (Input.GetAxis ("RightTrigger") > 0) {
			fireRight = true;
			Debug.Log ("fireRight: " + fireRight);
		} 
//		if (Input.GetButtonDown ("Start Button")) {
//				mainCamera.enabled = false;
//				secondaryCamera.enabled = true;
//			Debug.Log ("mainCam is currently: " + mainCamera.enabled + ", secondaryCam is: " + secondaryCamera.enabled);
//		}
//		if (Input.GetButtonDown ("Select Button")) {
//			{
//				mainCamera.enabled = true;
//				secondaryCamera.enabled = false;
//			}
//			Debug.Log ("mainCam is currently: " + mainCamera.enabled + ", secondaryCam is: " + secondaryCamera.enabled);
//		}
	}
}

