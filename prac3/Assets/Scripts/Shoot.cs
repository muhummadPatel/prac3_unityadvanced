/*
 * This script is attached to the gunMuzzle gameobject. It handles the "shooting" behaviour.
 * It uses the linerenderer component to draw a line out to the range that the gun can shoot
 * to. It also handles telling objects to be destroyed/explode. It uses raycasting to determine
 * whether the shot being fired has hit anything or not. The gunshot sound is also activated  here.
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	//tweakable params to change shooting beghaviour
	public float shotLineRange = 100.0f;
	public float recoilTime = 0.15f;
	public float shotLineDuration = 0.01f;
	public GameObject crossHair;

	float lastShot = 0.0f;

	AudioSource shotSound;
	ParticleSystem muzzleFlash;
	LineRenderer shotLine;

	// Use this for initialization
	void Start () {
		shotSound = GetComponent <AudioSource> ();
		muzzleFlash = GetComponent <ParticleSystem> ();
		shotLine = GetComponent <LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		lastShot += Time.deltaTime;

		if (lastShot >= recoilTime && Input.GetButtonUp ("Fire1")) {
			singleShot ();
			lastShot = 0.0f;
		} else {
			//player can actually shoot, but we still do a raycast to update the position of the crosshair sphere
			RaycastHit hit;
			Vector3 hitPoint;
			if (Physics.Raycast (transform.position, transform.forward, out hit, shotLineRange)) {
				hitPoint = hit.point;	
			} else {
				hitPoint = transform.position + (transform.forward * shotLineRange);
			}
			crossHair.transform.position = hitPoint; //update position of crosshair
		}

		if (lastShot >= shotLineDuration) {
			//disable the linerenderer. Don't want it to be enabled forever.
			shotLine.enabled = false;
		}
	}

	//Fire a single shot forwards from this gameobject
	void singleShot () {
		//play muzzleFlash particle system
		muzzleFlash.Stop ();
		muzzleFlash.Play ();

		//play gunshot audio
		shotSound.Play ();

		//set up the linerenderer
		shotLine.enabled = true;
		shotLine.SetPosition (0, transform.position);

		//Do raycast to determine what was hit (if anything)
		RaycastHit hit;
		Vector3 hitPoint;
		if (Physics.Raycast (transform.position, transform.forward, out hit, shotLineRange)) {
			hitPoint = hit.point;
			if (hit.collider.gameObject.tag == "Destructable") {
				//If ewe hit a destructable object, tell it to explode
				TakeDamage damage = hit.collider.gameObject.GetComponent<TakeDamage> ();
				damage.explode ();
			}			
		} else {
			//Fire a shot into space
			hitPoint = transform.position + (transform.forward * shotLineRange);
		}

		shotLine.SetPosition (1, hitPoint); //second vertex for the linerenderer

		crossHair.transform.position = hitPoint; //update position of the crosshair
	}
}
