using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	Vector3 movement;
	//Animator anim;
	PlayerMovement playerMovement;
	PlayerView playerView;

	void Start() {
		playerMovement = GetComponent<PlayerMovement> ();
		playerView = GetComponent <PlayerView> ();
	}

	// Update is called once per frame
//	void Update () {
//		Vector3 rot = new Vector3(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
//		rot += transform.rotation.eulerAngles;
//		transform.rotation = Quaternion.Euler(rot);
//	}
	
	void Update() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		if (Input.GetKeyUp(KeyCode.V)) {
			playerView.toggleViews();
			//Debug.Log ("Pressed");
		}

		playerMovement.move (h, v);
	}
}
