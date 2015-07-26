/*
 * This script makes the attached gameobject destructable/able to take damage.
 * It provides a public explode fuinction which, as the name suggests, will cause
 * the gameobject to explode. A particle system is instantiated at the location 
 * of the gameobject to show the explosion and the gameobject is then destroyed.
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	public ParticleSystem explosion;
	Manager manager;

	// Use this for initialization
	void Start () {
		GameObject managerObject = GameObject.FindGameObjectWithTag ("Manager");
		manager = managerObject.GetComponent<Manager> ();
	}

	public void explode() {
		manager.incrementDestroyed ();

		//instantiate explosion particle system at the location of this gameobject
		ParticleSystem explosionObj = (ParticleSystem) Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (explosionObj, 5.0f);

		//destroy the gameobject
		Destroy (this.gameObject);
	}
}
