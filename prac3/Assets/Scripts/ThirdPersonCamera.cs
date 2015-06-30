using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;
	
	Vector3 offset;
	
	void Start () {
		offset = transform.position - target.position;
	}
	
	void FixedUpdate () {
		//uncomment if slow
		//if (camera.enabled) {
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
		//}
	}
}
