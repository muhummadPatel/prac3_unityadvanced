/*
 * GameObjects with this script will have a material randomly assigned to them at runtime.
 * This script keeps an array with references to all the possible materials and at runtime,
 * one of these materials is randomly selected and applied to the attached gamneobject.
 * 
 * 27-July-2015
 * Muhummad Patel	PTLMUH006
 */

using UnityEngine;
using System.Collections;

public class RandomMaterial : MonoBehaviour {

	//list of references to the possible materials that could be applied to the gameobject
	public Material[] materials;

	// Use this for initialization
	void Start () {
		//randomly assign one of the materials ot the gameobject.
		int matIndex = Random.Range (0, materials.Length);
		this.renderer.material = materials [matIndex];
	}
}
