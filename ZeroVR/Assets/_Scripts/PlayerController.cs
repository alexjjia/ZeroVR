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
	public float moveSpeed;
	public float turnSpeed;
	public float jumpPower;
	public float gravity;
	public int distance;
	private bool fireLeft;
	private bool fireRight;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		mainCamera.enabled = true;
//		secondaryCamera.enabled = false;
		moveSpeed = 8;
		turnSpeed = 6;
		jumpPower = 16;
		gravity = 9.8f;
		fireLeft = false;
		fireRight = false;

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

		if (Input.GetAxis ("LeftTrigger") > 0) {
			fireLeft = true;
			Debug.Log ("fireLeft: " + fireLeft);
			}
		if (Input.GetAxis ("LeftTrigger") == 0) {
			fireLeft = false;
//			Debug.Log ("fireLeft: " + fireLeft);
		}
		if (Input.GetAxis ("RightTrigger") > 0) {
			fireRight = true;
//			Debug.Log ("fireRight: " + fireRight);
		}
		if (Input.GetAxis ("RightTrigger") == 0) {
			fireRight = false;
//			Debug.Log ("fireRight: " + fireRight);
		}


/** Might implement this, might not. It basically toggles between two different cameras (one being a "bird's eye view", the other being the "first person view". **/
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

