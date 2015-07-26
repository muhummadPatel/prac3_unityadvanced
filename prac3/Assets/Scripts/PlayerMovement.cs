/*
 * This script moves the player gameobject using the value of the movement vector. It does not handle any input.
 * The playerInputscript will invoke the move method and will pass in the required movement. This script handles
 * setting the triggers for animation of the player model.
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;

	Vector3 movement;
	Rigidbody playerRigidbody;
	Animator playerAnimator;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody> ();
		playerAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per physics step
	void FixedUpdate () {
			movement = movement.normalized * speed * Time.deltaTime;

			float yOff = transform.rotation.eulerAngles.y;
			movement = Quaternion.AngleAxis (yOff, Vector3.up) * movement;
		
			playerRigidbody.MovePosition (transform.position + movement);
	}

	//invoked by the playerInput script to set the movement Vector
	//Also fires relevant trigger for animationController to play the correct animation
	public void move (float horizontal, float vertical) {
		movement = new Vector3 (horizontal, 0.0f, vertical);

		//setting off the appropriate triggers for the animationController
		playerAnimator.SetBool ("isWalkingForward", vertical > 0 && horizontal == 0);
		playerAnimator.SetBool ("isWalkingBackward", vertical < 0 && horizontal == 0);
		playerAnimator.SetBool ("isStrafingRight", (horizontal > 0 && vertical >= 0)||(horizontal < 0 && vertical < 0));
		playerAnimator.SetBool ("isStrafingLeft", (horizontal < 0 && vertical >= 0)||(horizontal > 0 && vertical < 0));
	}
}
