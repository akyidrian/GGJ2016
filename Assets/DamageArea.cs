using UnityEngine;
using System.Collections;

public class DamageArea : MonoBehaviour {
	
	public int damage = 5;
	public float attackDelay = 1f;
	private float timer;

	void Awake() {
		timer = 0f;
	}

	void Update() {
		timer += Time.deltaTime;
	}

	void OnTriggerStay(Collider other) {

		if(timer >= attackDelay && other.tag == "Enemy") {
			other.GetComponent<Enemy>().Damage(damage);
			timer = 0f;
			Debug.Log ("Hit enemy!");
		}
	}
}
