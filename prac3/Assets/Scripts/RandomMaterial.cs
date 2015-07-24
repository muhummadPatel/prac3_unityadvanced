using UnityEngine;
using System.Collections;

public class RandomMaterial : MonoBehaviour {

	public Material[] materials;

	// Use this for initialization
	void Start () {
		int matIndex = Random.Range (0, materials.Length);
		this.renderer.material = materials [matIndex];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
