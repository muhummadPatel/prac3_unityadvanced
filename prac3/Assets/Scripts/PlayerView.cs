using UnityEngine;
using System.Collections;

public class PlayerView : MonoBehaviour {

	//change this to private for final build
	public int view;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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

	public void toggleViews (){
		//TODO: fix this! manually clamp to range and wrap around
		//wrapping around so we cant use clamp
		Mathf.Clamp(++view, 0, 2);
	}
}
