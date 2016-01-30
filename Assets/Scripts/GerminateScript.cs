using UnityEngine;
using System.Collections;

public class GerminateScript : MonoBehaviour {

	public GameObject treePrefab;	

	void OnTriggerEnter(Collider other) {

		Quaternion rotation = Quaternion.AngleAxis(270, Vector3.right);		
		GameObject tree = Instantiate(treePrefab, transform.position, rotation) as GameObject;
		Destroy(gameObject);

	}
}


