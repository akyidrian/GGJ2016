using UnityEngine;
using System.Collections;

public class TreeBehaviour : MonoBehaviour {

	public int health = 10;
	public int healthGrowthFactor = 10;
	public float growSpeed = 0.1f;
	public float minSize = 0.1f;
	public float maxSize = 1.0f;
	public Mesh[] treeMeshes;

	private float currentSize;
	private float timer;

	void Awake() {
		timer = 0;
		currentSize = minSize;
		AssignRandomMesh();
		transform.localScale = new Vector3(minSize, minSize, minSize);

	}

	void Update() {
		if(currentSize < maxSize) {
			currentSize = Mathf.Lerp(minSize, maxSize, timer * growSpeed);
			transform.localScale = new Vector3(currentSize, currentSize, currentSize);
			health = (int)(currentSize * 100);

		}
		timer += Time.deltaTime;
	}

	public void Damage(int damage) {
		health -= damage;
		currentSize = health/100;

		if(health <= 0) Destroy(gameObject);
	}

	private void AssignRandomMesh() {
		Mesh randomMesh = treeMeshes[Random.Range(0, treeMeshes.Length -1)];
		MeshFilter meshFilter = GetComponent<MeshFilter>();
		meshFilter.mesh = randomMesh;
	}
}
