using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public GameObject player;
	public float gunRange = 75f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 target;
		Ray ray;

		PlayerInput pi = player.GetComponent<PlayerInput>();
		if (pi.view == 2) {
			//FPV
			GameObject cameraObject = GameObject.FindGameObjectWithTag ("MainCamera");

			//new Vector3 (0.5f, 0.5f, 0f)
			ray = cameraObject.camera.ScreenPointToRay (Input.mousePosition); // This is assuming your crosshair is in the middle of the screen
		} else {
			//TPV or orbit cam
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		}

		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			target = hit.point; // We hit something, aim at that
			Debug.Log("Hit " + hit.ToString());
		} else {
			target = ray.GetPoint (gunRange); // Distance we're aiming at, could be something else
		}

		transform.LookAt (target);
	}
}
