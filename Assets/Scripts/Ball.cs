using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	//Variables
	public float BallSpeed = 600f;

	private Rigidbody rb;
	private bool play; //boolean to know if the ball is in play
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && play == false) {
			transform.parent = null; // Bar isn't parent from Ball anymore
			play = true;
			rb.isKinematic = false;
			rb.AddForce (new Vector3 (BallSpeed, BallSpeed, 0)); //Send the ball in a direction 
		}
	}
}
