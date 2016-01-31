using UnityEngine;
using System.Collections;

public class Enemy : MovableObject {

	public int health = 10;
    public int attackPower = 5; // Amount of health to take off tree.
    public EnemyManager enemyManager;

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

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tree")
        {
            TreeBehaviour tree = other.GetComponent<TreeBehaviour>();
            tree.Damage(attackPower);
        }
    }

    void Update()
    {
        base.Update();

        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        Vector3 target = GetClosestTarget(trees);
        SetNewPosition(target);
    }

    void OnDestroy ()
    {
        enemyManager.enemyDeathNotify();
    }
}
