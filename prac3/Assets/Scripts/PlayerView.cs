using UnityEngine;
using System.Collections;

public class PlayerView : MonoBehaviour {

	//change this to private for final build
	public int view;

	public float heightStep = 0.5f;
	public float radiusStep = 0.5f;

	GameObject[] cams;
	OrbitingCamera orbitController;

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

	public void toggleViews (){
		view++;

		if (view == cams.Length) {
			view = 0;
		}
	}

	public void adjustOrbitCamHeight(int direction) {
		direction = direction / Mathf.Abs(direction);
		orbitController.adjustHeight (direction * heightStep);
	}

	public void adjustOrbitCamRadius (int direction) {
		direction = direction / Mathf.Abs(direction);
		orbitController.adjustRadius (direction * radiusStep);
	}
}
