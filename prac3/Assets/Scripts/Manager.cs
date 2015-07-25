using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	GameObject player;
	public Material[] materials;
	public GameObject[] destructables;
	public int maxDestructablesInScene = 5;
	public int totalDestructables = 700;
	public float spawnDelay = 2.0f;
	public float spawnHeight = 15.0f;
	public float spawnRadius = 30.0f;

	int destroyed = 0;
	int deployed = 0;
	float spawnTimer = 0f;

	public void decrementDeployed(){
		deployed--;
	}

	public void incrementDestroyed(){
		destroyed++;
		Debug.Log ("destroyed " + destroyed);
	}

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;

		player = GameObject.FindGameObjectWithTag ("Player");

		for (int i = 0; i < maxDestructablesInScene; i++) {
			spawnDestructable ();
			deployed++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		int current = deployed - destroyed;
		//Debug.Log ("deployed " + deployed + " current " + current);
		if (deployed < totalDestructables && spawnTimer >= spawnDelay && current < maxDestructablesInScene){
			spawnDestructable();

			spawnTimer = 0;
			deployed++;
			//Debug.Log(deployed);
		}

		spawnTimer += Time.deltaTime;
	}

	void spawnDestructable(){
		int destrIndex = Random.Range (0, destructables.Length);
		int matIndex = Random.Range (0, materials.Length);

		Vector3 centre = player.transform.position;
		float[] randCoords = {
								Random.Range(centre.x - spawnRadius, centre.x + spawnRadius),
								spawnHeight,
								Random.Range (centre.z - spawnRadius, centre.z + spawnRadius)};

		Vector3 randomLocation = new Vector3(randCoords[0], randCoords[1], randCoords[2]);
		randomLocation.y = spawnHeight;

		//Spawn itself
		GameObject go = (GameObject)Instantiate(destructables[destrIndex], randomLocation, Quaternion.identity); //TODO: random rotation?
		go.renderer.material = materials [matIndex];
		//float grav = 9.8f;
		//go.rigidbody.velocity = Vector3.down.normalized * grav;
	}
}
