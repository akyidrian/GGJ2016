using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 5f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int maxEnemies = 4;
    private int enemyCounter = 0;


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if (enemyCounter < maxEnemies)
        {
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            GameObject enemyInstance = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;

            enemyInstance.GetComponent<Enemy>().enemyManager = this;
            enemyCounter += 1;
        }
    }

    public void enemyDeathNotify()
    {
        enemyCounter -= 1;
    }
}