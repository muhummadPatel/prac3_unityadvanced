using UnityEngine;
using System.Collections;

public class RespawnOnCollision : MonoBehaviour {

	//public GameObject managerObject;

	Manager manager;

	// Use this for initialization
	void Start () {
		GameObject managerObject = GameObject.FindGameObjectWithTag ("Manager");
		manager = managerObject.GetComponent<Manager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){

		if(collision.collider.gameObject.tag == "Destructable"){
			Debug.Log ("decrementing deployed" + collision.collider.gameObject.tag);
			manager.decrementDeployed();
			Destroy (this.gameObject);
		}
	}
}
