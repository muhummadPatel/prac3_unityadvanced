using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public GameObject player;
	public GameObject[] destructables;
	public int maxDestructablesInScene = 5;
	public int totalDestructables = 7;
	public float spawnDelay = 5.0f;
	public float spawnHeight = 3.0f;
	public float spawnRadius = 25.0f;

	int destroyed = 0;
	int deployed = 0;
	float spawnTimer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int current = deployed - destroyed;
		if (deployed < totalDestructables && current < maxDestructablesInScene) {
			spawnDestructable();

			spawnTimer = 0;
			deployed++;
			Debug.Log(deployed);
		}

		spawnTimer += Time.deltaTime;
	}

	void spawnDestructable(){
		int index = Random.Range (0, destructables.Length-1);

		Vector3 centre = player.transform.position;
		float[] randCoords = {
								Random.Range(centre.x - spawnRadius, centre.x + spawnRadius),
								spawnHeight,
								Random.Range (centre.z - spawnRadius, centre.z + spawnRadius)};

		Vector3 randomLocation = new Vector3(randCoords[0], randCoords[1], randCoords[2]);
		randomLocation.y = spawnHeight;

		//Spawn itself
		GameObject go = (GameObject)Instantiate(destructables[index], randomLocation, Quaternion.identity); //TODO: random rotation?
		//float grav = 9.8f;
		//go.rigidbody.velocity = Vector3.down.normalized * grav;
	}
}
