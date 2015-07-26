/*
 * The FirstPersonCamera class controls the movement and rotation of the first 
 * person camera gameobject that is a child of the player gameobject. The camera
 * view is moved by the mouse. As the mouse moves, the camera folllows.
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour {

	//tweakable parameters to adjust the movement of the camera
	public float sensitivityX = 2F;
	public float sensitivityY = 2F;
	
	public float minY = -30F;
	public float maxY = 30F;

	//private variables for use in this script.
	GameObject player;
	float rotY = 0F;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {

		//Yaw. Rotate player side to side.
		Vector3 rotX = new Vector3(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		rotX += player.transform.rotation.eulerAngles;
		player.transform.rotation = Quaternion.Euler(rotX);

		//Pitch. Rotate camera up and down.
		rotY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotY = Mathf.Clamp (rotY, minY, maxY);
		transform.localEulerAngles = new Vector3(-rotY, transform.localEulerAngles.y, 0);
	}
}
