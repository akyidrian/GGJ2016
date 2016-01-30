using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float destroyAfterSeconds = 10;

	void Awake () {
		Destroy(gameObject, destroyAfterSeconds);
	}

}
