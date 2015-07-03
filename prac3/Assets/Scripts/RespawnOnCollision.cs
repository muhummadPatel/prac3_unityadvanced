using UnityEngine;
using System.Collections;

public class RespawnOnCollision : MonoBehaviour {

	//public GameObject managerObject;

	Manager manager;
	bool hitGround = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){

		if (hitGround) {
			if (collision.collider.gameObject.tag == "Destructable") {
				Debug.Log ("decrementing deployed" + collision.collider.gameObject.tag);
				GameObject managerObject = GameObject.FindGameObjectWithTag ("Manager");
				manager = managerObject.GetComponent<Manager> ();
				manager.decrementDeployed ();
				Destroy (this.gameObject);
			} else if (collision.collider.gameObject.tag == "Ground") {
				hitGround = true;
			}
		}
	}
}
