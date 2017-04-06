using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_HitDetectionController : MonoBehaviour {
	private float timestamp; //our lovely stopwatch, keeps track of time elapsed.
	private int lastHitDelay; //how long since an object hits said demoObject. Used for resetting demoObjects' states.

	// Use this for initialization
	void Start () {
		lastHitDelay = 3; //after three seconds, we will reset the hit demoObject.
	}
	
	/* *
	 * Set up a timer.
	 * When projectile hits said demoObject
	 * change color of demoObject / send some sort of player notification of hit.
	 * after a set amount of time, reset demoObject to initial state or whatever.
	 * reset timer.
	 * */
	void Update()
	{

	}

	void OnTriggerEnter (Collider other) //upon collision, destroy bullet object, and change color of hit randomly.
	{
		if (other.gameObject.CompareTag("PlayerProjectile")) {
			//other.gameObject.SetActive (false);
			Destroy(other.gameObject);
			gameObject.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value, 1.0f);

		}
	}
}