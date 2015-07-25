using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public float range = 50.0f;
	public float recoilTime = 0.15f;
	public float shotLineDuration = 0.01f;

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
			singleShot();
			lastShot = 0.0f;
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
		if (Physics.Raycast (transform.position, transform.forward, out hit, range)) {
			hitPoint = hit.point;
			if (hit.collider.gameObject.tag == "Destructable") {
				TakeDamage damage = hit.collider.gameObject.GetComponent<TakeDamage> ();
				damage.explode ();
			}			
		} else {
			hitPoint = transform.position + (transform.forward * 50);
		}

		shotLine.SetPosition (1, hitPoint);
	}

}
