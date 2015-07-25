using UnityEngine;
using System.Collections;

public class PlayerView : MonoBehaviour {

	//change this to private for final build
	public int view;

	GameObject[] cams;

	// Use this for initialization
	void Start () {
		cams = new GameObject[3];
	}
	
	// Update is called once per frame
	void Update () {

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

	public void toggleViews (){
		view++;

		if (view == cams.Length) {
			view = 0;
		}
	}
}
