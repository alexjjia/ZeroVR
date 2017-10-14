using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Vector3 movementVector;
	private float verticalMove, horizontalMove, horizontalTurn;
	private CharacterController characterController;

	//test values.
	public Camera mainCamera;
	public GameObject leftCannon;
	public GameObject rightCannon;
	public GameObject bullet;

//	public Camera secondaryCamera;
	public float moveSpeed;
	public float turnSpeed;
	public float jumpPower;
	public float gravity;
	public int distance;
	public int projectileSpeed;
	private bool fireLeft;
	private bool fireRight;
	private float timestamp;
	private float fireDelay;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		mainCamera.enabled = true;
//		secondaryCamera.enabled = false;
		moveSpeed = 8;
		turnSpeed = 6;
		jumpPower = 16;
		projectileSpeed = 50;
		gravity = 9.8f;
		fireLeft = false;
		fireRight = false;
		fireDelay = 0.2f;
//		debugMode = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Player Movement


		if (characterController.isGrounded) { //while the player is grounded, he/she can move.
			movementVector.y = 0; //resets the dood.
			movementVector = (transform.forward * Input.GetAxis ("LeftJoystickY") * moveSpeed) + (transform.right * Input.GetAxis("LeftJoystickX") * moveSpeed); //controls actual movement.

			if (Input.GetButtonDown ("A")) { //controls jumping.
				movementVector.y = jumpPower;
			}
		}
		horizontalTurn = Input.GetAxis ("RightJoystickX") * turnSpeed; //controls turning.
		movementVector.y -= gravity * Time.deltaTime;
		transform.Rotate (new Vector3 (0, horizontalTurn, 0));
		characterController.Move(movementVector * Time.deltaTime);


		//Other input controls.
		if (Input.GetAxis ("LeftTrigger") > 0) {		//if left trigger is pressed, set shooting flag to true.
			fireLeft = true;
//			Debug.Log ("fireLeft: " + fireLeft);
			}
		if (Input.GetAxis ("RightTrigger") > 0) {		//if right trigger is pressed, set shooting flag to true.
			fireRight = true;
			//			Debug.Log ("fireRight: " + fireRight);
		}
		if (Input.GetAxis ("LeftTrigger") == 0) {		//if left trigger is released, set shooting flag to false.
			fireLeft = false;
//			Debug.Log ("fireLeft: " + fireLeft);
		}
		if (Input.GetAxis ("RightTrigger") == 0) {		//if right trigger is released, set shooting flag to false.
			fireRight = false;
//			Debug.Log ("fireRight: " + fireRight);
		}

		if (Time.time >= timestamp) {					//Time.time controls the fire rate, so to speak. (i.e the delay between shots).
		
			if (fireLeft == true && fireRight == true) {		//shooting with both triggers at once.
				fire (leftCannon);
				fire (rightCannon);
			}/* else if (fireRight == true && fireLeft == true) {
				fire (leftCannon);
				fire (rightCannon);
			}*/ else if (fireLeft == false && fireRight == true) {		//shooting with only the right trigger.
				fire (rightCannon);
			} else if (fireRight == false && fireLeft == true) {		//shooting with only the left trigger.
				fire (leftCannon);
			}
			timestamp = Time.time + fireDelay;					//updates the 'timestamp' variable.
		}

	//	print ("BOOL STATUS: L - " + fireLeft + ", R - " + fireRight);
	}

	/**
	 * Actual firing/shooting function.
	 * 
	 **/
	void fire(GameObject cannon)
	{
		GameObject projectile = Instantiate (bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
		Rigidbody rb = projectile.GetComponent<Rigidbody>();

		rb.AddForce (projectile.transform.forward * projectileSpeed, ForceMode.Impulse);
		//print ("bullet's vector is at: " + bullet.transform.forward);
		Destroy (projectile, 3.0f);
	}
}

