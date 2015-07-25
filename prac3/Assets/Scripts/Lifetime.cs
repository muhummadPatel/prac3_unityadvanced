using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour {

	public float timeToLive = 5.0f;

	float timeAlive = 0.0f;

	// Use this for initialization
	void Start () {
		//use this instead?
		//Destroy(this.gameObject, timeToLive);
	}
	
	// Update is called once per frame
	void Update () {
		timeAlive += Time.deltaTime;

		if (timeAlive >= timeToLive) {
			Destroy(this.gameObject);
		}
	}
}