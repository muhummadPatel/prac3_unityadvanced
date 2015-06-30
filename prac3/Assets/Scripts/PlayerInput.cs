using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public float speed = 6f;
	
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	void Start() {
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		
		Move (h, v);
	}
	
	void Move(float h, float v) {
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		
		playerRigidbody.MovePosition (transform.position + movement);
	}
}
