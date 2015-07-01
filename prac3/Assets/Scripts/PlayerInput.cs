using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public float speed = 6f;

	public int view;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;

	void Start() {
		playerRigidbody = GetComponent<Rigidbody> ();

		UpdateCam (view);
	}

	// Update is called once per frame
//	void Update () {
//		Vector3 rot = new Vector3(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
//		rot += transform.rotation.eulerAngles;
//		transform.rotation = Quaternion.Euler(rot);
//	}
	
	void FixedUpdate() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");


		
		Move (h, v);
		UpdateCam (view);
	}

	void Move (float h, float v) {
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		//Debug.Log (transform.rotation.eulerAngles.y);
		float yOff = transform.rotation.eulerAngles.y;
		movement = Quaternion.AngleAxis(yOff, Vector3.up) * movement;
		
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void UpdateCam (int view){
		//view = Mathf.Clamp (view, 0, 2);

		GameObject[] cams = new GameObject[3];
		cams[0] = GameObject.Find ("Orbit Camera");
		cams[1] = GameObject.Find ("Third Person Camera");
		cams[2] = GameObject.Find ("First Person Camera");

		foreach (GameObject cameraObject in cams) {
			cameraObject.camera.enabled = false;
			cameraObject.tag = "Camera";
		}

		cams[view].camera.enabled = true;
		cams[view].tag = "MainCamera";
	}
}
