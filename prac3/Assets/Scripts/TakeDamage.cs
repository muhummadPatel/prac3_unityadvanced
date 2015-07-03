using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	//public GameObject managerObject; // dont set this in the prefab

	public ParticleSystem explosion;
	Manager manager;

	// Use this for initialization
	void Start () {
		GameObject managerObject = GameObject.FindGameObjectWithTag ("Manager");
		manager = managerObject.GetComponent<Manager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void explode() {
		//Debug.Log ("ded");

		manager.incrementDestroyed ();

		Instantiate (explosion, transform.position, Quaternion.identity);

		Destroy (this.gameObject);
	}
}
