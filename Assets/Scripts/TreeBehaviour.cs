using UnityEngine;
using System.Collections;

public class TreeBehaviour : MonoBehaviour {

	public int health = 10;
	public float growSpeed = 0.1f;
	public float minSize = 0.1f;
	public float maxSize = 1.0f;
	public Mesh[] treeMeshes;

	private float currentSize;

	void Awake() {
		currentSize = minSize;
		AssignRandomMesh();
		transform.localScale = new Vector3(minSize, minSize, minSize);

	}

	void Update() {

		if(currentSize < maxSize) {
			currentSize += Time.deltaTime * growSpeed;
			transform.localScale = new Vector3(currentSize , currentSize, currentSize);

			health = (int)(currentSize * 100);
		}

	}

	public void Damage(int damage) {
		health -= damage;
		currentSize = (float)health/100f;

		if(health <= 0) Destroy(gameObject);
	}

	private void AssignRandomMesh() {
		Mesh randomMesh = treeMeshes[Random.Range(0, treeMeshes.Length -1)];
		MeshFilter meshFilter = GetComponent<MeshFilter>();
		meshFilter.mesh = randomMesh;
	}
}
