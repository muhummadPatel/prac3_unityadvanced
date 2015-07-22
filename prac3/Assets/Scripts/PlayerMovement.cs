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
		
		//Debug.Log (transform.rotation.eulerAngles.y);
		float yOff = transform.rotation.eulerAngles.y;
		movement = Quaternion.AngleAxis(yOff, Vector3.up) * movement;
		
		playerRigidbody.MovePosition (transform.position + movement);
	}

	public void move (float horizontal, float vertical) {
		movement = new Vector3 (horizontal, 0.0f, vertical);

		playerAnimator.SetBool ("isWalkingForward", vertical > 0 && horizontal == 0);
		playerAnimator.SetBool ("isWalkingBackward", vertical < 0 && horizontal == 0);
		playerAnimator.SetBool ("isStrafingRight", (horizontal > 0 && vertical >= 0)||(horizontal < 0 && vertical < 0));
		playerAnimator.SetBool ("isStrafingLeft", (horizontal < 0 && vertical >= 0)||(horizontal > 0 && vertical < 0));
	}
}
