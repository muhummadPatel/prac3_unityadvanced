using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public float shotLineRange = 100.0f;
	public float recoilTime = 0.15f;
	public float shotLineDuration = 0.01f;
	public GameObject crossHair;

	float lastShot = 0.0f;

	ParticleSystem muzzleFlash;
	LineRenderer shotLine;

	// Use this for initialization
	void Start () {
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
			RaycastHit hit;
			Vector3 hitPoint;
			if (Physics.Raycast (transform.position, transform.forward, out hit, shotLineRange)) {
				hitPoint = hit.point;	
			} else {
				hitPoint = transform.position + (transform.forward * shotLineRange);
			}
			crossHair.transform.position = hitPoint;
		}

		if (lastShot >= shotLineDuration) {
			shotLine.enabled = false;
		}
	}

	void singleShot () {
		//Debug.Log ("shot");
		muzzleFlash.Stop ();
		muzzleFlash.Play ();

		shotLine.enabled = true;
		shotLine.SetPosition (0, transform.position);
		
		RaycastHit hit;
		Vector3 hitPoint;
		if (Physics.Raycast (transform.position, transform.forward, out hit, shotLineRange)) {
			hitPoint = hit.point;
			if (hit.collider.gameObject.tag == "Destructable") {
				TakeDamage damage = hit.collider.gameObject.GetComponent<TakeDamage> ();
				damage.explode ();
			}			
		} else {
			hitPoint = transform.position + (transform.forward * shotLineRange);
		}

		shotLine.SetPosition (1, hitPoint);

		crossHair.transform.position = hitPoint;
	}

}
