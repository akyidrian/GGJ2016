using UnityEngine;
using System.Collections;

public class PlanterController : MonoBehaviour {

	public float plantingDelay;
	public GameObject seed;
	
	void Awake () {
		StartCoroutine (PlantSeed());
	}

	void Update () {
	
	}

	IEnumerator PlantSeed() {
		while(true) {

			Instantiate(seed, transform.position, Quaternion.identity);
			yield return new WaitForSeconds (plantingDelay);
		}
	}

	// Not used yet.
	Vector3 RandomCircle( Vector3 center, float radius) {
		float angle = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin (angle * Mathf.Deg2Rad);
		pos.y = center.y + radius * Mathf.Cos (angle * Mathf.Deg2Rad);
		pos.z = center.z;

		return pos;
	}
}
