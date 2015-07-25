using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	Vector3 movement;
	Manager manager;
	//Animator anim;
	PlayerMovement playerMovement;
	PlayerView playerView;

	void Start() {
		GameObject managerObject = GameObject.FindGameObjectWithTag ("Manager");
		manager = managerObject.GetComponent<Manager> ();

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

		if (Input.GetKey (KeyCode.Period)) {
			//increase height of orbit cam
			playerView.adjustOrbitCamHeight (1);
		} else if (Input.GetKey (KeyCode.Comma)) {
			//decrease orbit cam height
			playerView.adjustOrbitCamHeight(-1);
		}

		if (Input.GetKey (KeyCode.K)) {
			//increase orbit cam radius
			playerView.adjustOrbitCamRadius (1);
		} else if (Input.GetKey (KeyCode.L)) {
			//decrease orbit cam radius
			playerView.adjustOrbitCamRadius(-1);
		}

		if (Input.GetKeyUp (KeyCode.R)) {
			manager.restart ();
		}

		playerMovement.move (h, v);
	}
}
