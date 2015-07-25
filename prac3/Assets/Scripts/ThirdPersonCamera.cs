﻿using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	GameObject target;
	public float rotateSpeed = 5;
	Vector3 offset;
	
	void Start() {
		target = GameObject.FindGameObjectWithTag ("Player");
		offset = target.transform.position - transform.position;
	}
	
	void Update() {
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		target.transform.Rotate(0, horizontal, 0);
		
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);
		
		transform.LookAt(target.transform);
	}
}
