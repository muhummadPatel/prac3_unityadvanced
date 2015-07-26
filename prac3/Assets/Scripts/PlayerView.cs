/*
 * This script switches between the three cameras in the scene, viz. FPV camera, third-person
 * camera, and orbit camera. The player input script will tell this script when to toggle between
 * thge available cameras. This script keeps references to each of the camera gameobjects in 
 * the scene.
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using System.Collections;

public class PlayerView : MonoBehaviour {

	public float heightStep = 0.5f;
	public float radiusStep = 0.5f;

	int view = 1; //current view/active camera
	GameObject[]  cams; //references to all the cameras in the scene
	OrbitingCamera orbitController; //orbitController script so we can change the params of the orbit cam

	// Use this for initialization
	void Start () {
		cams = new GameObject[3];
	}
	
	// Update is called once per frame
	void Update () {

		cams[0] = GameObject.Find ("Orbit Camera");
		cams[1] = GameObject.Find ("Third Person Camera");
		cams[2] = GameObject.Find ("First Person Camera");

		orbitController = cams [0].GetComponent <OrbitingCamera> ();

		foreach (GameObject cameraObject in cams) {
			cameraObject.camera.enabled = false;
			cameraObject.tag = "Camera";
		}
		
		cams[view].camera.enabled = true;
		cams[view].tag = "MainCamera";
	}

	//called by the player input script when the player asks to toggle cams.
	//increments the view variable (wraps around when it goes out of bounds).
	public void toggleViews (){
		view++;

		if (view == cams.Length) {
			view = 0;
		}
	}

	//Changes the orbitCam height either up or down based on whether direction is a +ve or -ve value
	public void adjustOrbitCamHeight(int direction) {
		direction = direction / Mathf.Abs(direction);
		orbitController.adjustHeight (direction * heightStep);
	}

	//Changes the orbitCam radius either up or down based on whether direction is a +ve or -ve value
	public void adjustOrbitCamRadius (int direction) {
		direction = direction / Mathf.Abs(direction);
		orbitController.adjustRadius (direction * radiusStep);
	}
}
