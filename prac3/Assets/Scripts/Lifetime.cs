/*
 * The Lifetime behaviour script gives the gameobject a limited lifetime.
 * This script keeps a timer running for the specified amount of time and
 * then destroys the gameobject it is attached to when the timer runs out.
 * Used to limit the lifetime of explosions and other such objects so that 
 * they don't clutter the scene and slow down gameplay.
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour {

	//time after which this object should be destroyed.
	public float timeToLive = 5.0f;

	float timeAlive = 0.0f; //time alive so far
	
	// Update is called once per frame
	void Update () {
		timeAlive += Time.deltaTime; //update time alive so far

		if (timeAlive >= timeToLive) {
			Destroy(this.gameObject);
		}
	}
}