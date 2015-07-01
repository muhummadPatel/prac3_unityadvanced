using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public GameObject player;
	public GameObject[] destructables;
	public int maxDestructablesInScene = 5;
	public int totalDestructables = 7;
	public float spawnRadius = 50;
	public float spawnDelay = 5.0f;

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
		}

		spawnTimer += Time.deltaTime;
	}

	void spawnDestructable(){
		int index = Random.Range (0, destructables.Length-1);

		Vector3 randomLocation = Random.insideUnitSphere * spawnRadius;
		randomLocation.y = 1.0f;
	
		//Spawn itself
		Instantiate(destructables[index], player.transform.position + randomLocation, destructables[index].transform.rotation);

		spawnTimer = 0;
		deployed++;
	}
}
