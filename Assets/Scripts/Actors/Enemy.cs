using UnityEngine;
using System.Collections;

public class Enemy : MovableObject {

	public int health = 10;

	public void Damage(int damage) {
		health -= damage;		
		if(health <= 0) Destroy(gameObject);
	}

    Vector3 GetClosestTarget(GameObject[] targets)
    {
        Vector3 closestTargetPos = new Vector3();
        float smallestDist = Mathf.Infinity;
        Vector3 currPos = transform.position;
        foreach (GameObject potentialTarget in targets)
        {
            Vector3 potentialTargetPos = potentialTarget.transform.position;
            Vector3 directionToTarget = potentialTargetPos - currPos;
            float distToTarget = directionToTarget.sqrMagnitude;
            if (distToTarget < smallestDist)
            {
                smallestDist = distToTarget;
                closestTargetPos = potentialTargetPos;
            }
        }

        return closestTargetPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tree")
        {
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        base.Update();

        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        Vector3 target = GetClosestTarget(trees);
        SetNewPosition(target);
    }
}
