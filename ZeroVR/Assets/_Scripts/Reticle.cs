using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour {
	public Camera cam;
	public GameObject canvas;
	public Text distanceText;
	private bool showHUD;
	private RaycastHit hit;
	private float distance;
	private Vector3 scale;
	private float maxTolerance = 20.0f; //max and min tolerance values for reticle distance, since distance directly affects size.
	private float minTolerance = 0.4f;

	// Use this for initialization
	void Start () {
		scale = transform.localScale;
		showHUD = false;
		showDistance ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Physics.Raycast (new Ray(cam.transform.position, cam.transform.rotation * Vector3.forward), out hit))
		{
				distance = hit.distance;
		}
		else
		{
			distance = cam.farClipPlane * 0.95f;
		}
		showDistance ();
		if (distance >= maxTolerance) {
			distance = maxTolerance;
		}else if (distance <= minTolerance) {
			distance = minTolerance;
		}
		transform.position = cam.transform.position + cam.transform.rotation * Vector3.forward*distance;
		transform.LookAt (cam.transform.position);
		transform.Rotate (0, 180f, 0); //to deal with the previous line.

		if (Input.GetButtonDown ("Start Button")) {
			showHUD = !showHUD;
		}

		transform.localScale = scale * (1+(1/distance)); //rescales the reticle based off size.

	}
	void showDistance()
	{
		canvas.SetActive (showHUD);
		distanceText.text = "Distance: " + Mathf.Round(distance).ToString();
	}

}
