/*
 * This script Handles all player input. All player keypresses are picked up 
 * here and the relevant action is then performed. This is often farmed out 
 * to the appropriate scripts. Eg. the V keypress is picked up by this script
 * which then informs the playerView script to switch to the next camera view.
 * Player input is also interpreted and sent to the playerMovement script to
 * move the player around the game world.
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	Manager manager;
	bool paused = false;

	PlayerMovement playerMovement;
	PlayerView playerView;

	void Start() {
		GameObject managerObject = GameObject.FindGameObjectWithTag ("Manager");
		manager = managerObject.GetComponent<Manager> ();

		playerMovement = GetComponent<PlayerMovement> ();
		playerView = GetComponent <PlayerView> ();
	}

	void Update() {

		if (Input.GetKey("escape")) {
			Application.Quit();
		}
		
		if (Input.GetKeyUp (KeyCode.H)) {
			//Show/hide help screen
			paused = !paused;
			manager.toggleHelpScreen(paused);
		}

		//only get this input when the game is NOT in a paused state
		if (!paused) {
			//get movement input
			float h = Input.GetAxisRaw ("Horizontal");
			float v = Input.GetAxisRaw ("Vertical");

			playerMovement.move (h, v);

			if (Input.GetKeyUp (KeyCode.V)) {
				//switch camera views
				playerView.toggleViews ();
			}

			if (Input.GetKey (KeyCode.Period)) {
				//increase height of orbit cam
				playerView.adjustOrbitCamHeight (1);
			} else if (Input.GetKey (KeyCode.Comma)) {
				//decrease orbit cam height
				playerView.adjustOrbitCamHeight (-1);
			}

			if (Input.GetKey (KeyCode.K)) {
				//increase orbit cam radius
				playerView.adjustOrbitCamRadius (1);
			} else if (Input.GetKey (KeyCode.L)) {
				//decrease orbit cam radius
				playerView.adjustOrbitCamRadius (-1);
			}

			if (Input.GetKeyUp (KeyCode.R)) {
				//restart the scene
				manager.restart ();
			}
		}
	}
}
