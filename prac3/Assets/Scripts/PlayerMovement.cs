using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;

	Vector3 movement;
	Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody> ();
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
	}
}
