using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log (collision.collider.gameObject.tag);
		if(collision.collider.gameObject.tag == "Destructable"){

			TakeDamage damage = collision.collider.GetComponent<TakeDamage>();
			damage.explode();
			Destroy (this.gameObject);
		}
	}
}
