/*
 * The ThirdPersonCamera class controls the movement of the Third Person camera.
 * The third person camera chases the player as they move. It stays directly behind
 * the playter gameobject and rotate with the player as they rotate. The movement
 * of the camera is smooth and we lerp from our position to the computed new position
 * to avoid jerky movement when starting or stopping (intial velocity of zero).
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	//so we can tweak how smoothly the camera rotates
	public float rotateSpeed = 5;

	GameObject player; //the target of the camera
	Vector3 offset; //how far away to stay from the player (based on position relative to player in the scene)
	
	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = player.transform.position - transform.position; //keep initial offset
	}
	
	void Update() {
		//Yaw. Rotate the player object based on mouse x movement.
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		player.transform.Rotate(0, horizontal, 0);

		//move the camera object to follow the player.
		float desiredAngle = player.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = player.transform.position - (rotation * offset);

		//keep the target in focus.
		transform.LookAt(player.transform);

		//Note: pitch (moving the gun up and down) is handled seperately.
		//(gun is a child of first person camera)
	}
}
