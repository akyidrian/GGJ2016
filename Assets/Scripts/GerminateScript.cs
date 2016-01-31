using UnityEngine;
using System.Collections;

public class GerminateScript : MonoBehaviour {

	public GameObject treePrefab;	

	void OnTriggerEnter(Collider other) {

		if(other.tag == "Grower") {
			Quaternion rotation = Quaternion.AngleAxis(270, Vector3.right);		
			Instantiate(treePrefab, transform.position, rotation);
			Destroy(gameObject);
		}

	}
}


