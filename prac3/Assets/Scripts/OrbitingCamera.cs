using UnityEngine;
using System.Collections;

public class OrbitingCamera : MonoBehaviour {

	GameObject target;
	public float step;
	public float distance;
	public float height;

	Vector3 offset;
	float theta = 0;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//uncomment if slow
		//if (camera.enabled) {
		theta += step;
		if (theta >= 360) {
			theta = 0;
		}

		//Transform angle in degree in quaternion form used by Unity for rotation.
		Quaternion rotation = Quaternion.Euler (transform.position.y, theta, 0.0f);
	
		//The new position is the target position + the distance vector of the camera
		//rotated at the specified angle.
		offset = new Vector3 (0.0f, 0.0f, -distance);
		Vector3 position = rotation * offset + target.transform.position;
	
		//Update the rotation and position of the camera.
		transform.rotation = rotation;

		position.y = height;
		transform.position = position;

		Vector3 relativePos = target.transform.position - transform.position;
		Quaternion rot = Quaternion.LookRotation (relativePos);
		transform.rotation = rot;
		//}
	}
}
