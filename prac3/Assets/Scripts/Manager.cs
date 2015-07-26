/*
 * The Manager script handles the core functionality of the level. It oversees the game
 * , spawns destructables, toggles the help screen, and handles restaring the scene.
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {

	//Keep references to UI elements that we need to access
	public Text scoreText;
	public GameObject helpScreen;

	//list of materials and destructable objects so we can randomly choose
	//shapes and textures to be spawned
	public Material[] materials;
	public GameObject[] destructables;

	//tweak volumes spawned
	public int maxDestructablesInScene = 5;
	public int totalDestructables = 700;

	//tweak spawn rate
	public float spawnDelay = 2.0f;
	public float spawnHeight = 15.0f;
	public float spawnRadius = 30.0f;

	//private variables to keep track of what is happening
	GameObject player;
	int destroyed = 0;
	int deployed = 0;
	float spawnTimer = 0f;

	//Increased when a destructable is destroyed/explodes.
	//Updates the score text on the hud.
	public void incrementDestroyed(){
		destroyed++;
		scoreText.text = "" + destroyed;
	}

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true; //capture the cursor

		player = GameObject.FindGameObjectWithTag ("Player");

		//intial wave of destructables
		for (int i = 0; i < maxDestructablesInScene; i++) {
			spawnDestructable ();
			deployed++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//spawn if required
		int current = deployed - destroyed;
		if (deployed < totalDestructables && spawnTimer >= spawnDelay && current < maxDestructablesInScene){
			spawnDestructable();

			spawnTimer = 0;
			deployed++;
			//Debug.Log(deployed);
		}

		spawnTimer += Time.deltaTime;
	}

	//spawns a randomly selected 3d object with a randomly selected material/texture
	void spawnDestructable(){
		//randomisation of object and texture
		int destrIndex = Random.Range (0, destructables.Length);
		int matIndex = Random.Range (0, materials.Length);

		Vector3 centre = Vector3.zero;
	
		//randomisation of location
		float[] randCoords = {
								Random.Range(centre.x - spawnRadius, centre.x + spawnRadius),
								spawnHeight,
								Random.Range (centre.z - spawnRadius, centre.z + spawnRadius)};

		Vector3 randomLocation = new Vector3(randCoords[0], randCoords[1], randCoords[2]);

		//Spawn itself
		GameObject go = (GameObject)Instantiate(destructables[destrIndex], randomLocation, Quaternion.identity); //TODO: random rotation?
		go.renderer.material = materials [matIndex];
	}

	//allow for the scene to be restarted
	public void restart () {
		Application.LoadLevel ("Level_01");
	}

	//toggles the visibility of the helpUI object.
	public void toggleHelpScreen (bool state) {
		helpScreen.SetActive (state);
	}
}
