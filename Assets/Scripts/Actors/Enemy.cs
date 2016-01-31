using UnityEngine;
using System.Collections;

public class Enemy : MovableObject {

	public int health = 10;
    public int attackPower = 10; // Amount of health to take off tree.
    public EnemyManager enemyManager;

    public float attackDelay = 0.5f;
    private float timer;

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

        if (timer >= attackDelay && other.tag == "Tree")
        {
            TreeBehaviour tree = other.GetComponent<TreeBehaviour>();
            tree.Damage(attackPower);
            timer = 0f;
            Debug.Log("Hit enemy!");
        }
    }

    void Awake()
    {
        base.Awake();
        timer = 0f;
    }

    void Update()
    {
        base.Update();

        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        Vector3 target = GetClosestTarget(trees);
        SetNewPosition(target);

        timer += Time.deltaTime;
    }

    void OnDestroy ()
    {
        enemyManager.enemyDeathNotify();
    }
}
