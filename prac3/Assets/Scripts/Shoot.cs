using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public float range = 50.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Fire1")) {
			Debug.Log ("shot");

			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit, range)){
				if (hit.collider.gameObject.tag == "Destructable") {
					TakeDamage damage = hit.collider.gameObject.GetComponent<TakeDamage>();
					damage.explode();
				}			}
		}
	}
}
