using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	float timer = 0f;
	Ray shootRay;
	RaycastHit shootHit;
//	LineRenderer gunLine;
	ParticleSystem muzzleFlash; 
	public float timeBetweenBullets = 0.5f;
	public float effectsDisplayTime = 0.5f;
	public float range = 150f;


	// Use this for initialization
	void Start () {
//		gunLine = GetComponent<LineRenderer> ();
		muzzleFlash = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
		{
			Shoot ();
		}
		
		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			DisableEffects ();
		}
	}

	public void DisableEffects (){
		//gunLine.enabled = false;
		//gunLight.enabled = false;
	}
	
	
	void Shoot (){
		timer = 0f;
		
//		gunAudio.Play ();
		
//		gunLight.enabled = true;
		
		muzzleFlash.Stop ();
		muzzleFlash.Play ();
//		
//		gunLine.enabled = true;
//		gunLine.SetPosition (0, transform.position);



		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		
//		if(Physics.Raycast (shootRay, out shootHit, range))
//		{
//			gunLine.SetPosition (1, shootHit.point);
//		}
//		else
//		{
//			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
//		}
	}
}
