/*
 * The OrbitingCamera class controls the movement of the orbiting camera.
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using System.Collections;

public class OrbitingCamera : MonoBehaviour {

	//tweakable params.
	public float step; //change in theta per frame
	public float distance; //distance from player
	public float height; //height above/below player

	GameObject player; //target (camera orbits this gameobject)
	Vector3 distanceVect; //distance to keep from target as vector
	float theta = 0; //current rotation angle

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//update rotation angle
		theta += step;
		if (theta >= 360) {
			theta = 0;
		}

		//compute rotation quaternion
		Quaternion rotation = Quaternion.Euler (transform.position.y, theta, 0.0f);
	
		//compute new position of camera.
		//rotate the distanceVect around target player by theta and then move the camera to the end of the distanceVect
		distanceVect = new Vector3 (0.0f, 0.0f, -distance);
		Vector3 position = rotation * distanceVect + player.transform.position;

		//Update the rotation and position of the camera.
		transform.rotation = rotation;

		position.y = height;
		transform.position = position;

		Vector3 relativePos = player.transform.position - transform.position;
		Quaternion rot = Quaternion.LookRotation (relativePos);
		transform.rotation = rot;
	}

	//allow adjustment of height from outside this script.
	public void adjustHeight(float delta) {
		height += delta;
	}

	//allow adjustment of radius from outside this script.
	public void adjustRadius (float delta) {
		distance += delta;
	}
}
