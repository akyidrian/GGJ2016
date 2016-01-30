using UnityEngine;
using System.Collections;

public class GerminateScript : MonoBehaviour {

	public GameObject[] trees;
	public Material treeMaterial;
	

	void OnTriggerEnter(Collider other) {

		Quaternion rotation = Quaternion.AngleAxis(270, Vector3.right);

		int randomIndex = Random.Range(0, trees.Length);
		GameObject tree = Instantiate(trees[randomIndex], transform.position, rotation) as GameObject;
		tree.GetComponent<Renderer>().material = treeMaterial;

		Destroy(gameObject);

	}
}


