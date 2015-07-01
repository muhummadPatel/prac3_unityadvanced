using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour {

	public GameObject player;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	float rotationY = 0F;

	
	void Update ()
	{

		//pitch
		Vector3 rot = new Vector3(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		rot += player.transform.rotation.eulerAngles;
		player.transform.rotation = Quaternion.Euler(rot);


		//yaw
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

		Debug.Log ("x: " +  Input.GetAxis("Mouse X") + "   y: " +  Input.GetAxis("Mouse Y"));

		transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
	}
}
