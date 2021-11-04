using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public static EnemySpawner instance;

    //Enemy prefabs
    public GameObject prefab;

    //Enemy spawn
    public Transform spawnPoint;

    //Enemy spawn interval
    public float spawnInterval = 5f;


    void Start()
    {
        StartSpawning();    
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        //Call the spawn method
        SpawnEnemy();

        yield return new WaitForSeconds(spawnInterval);

        StartCoroutine(SpawnDelay());
    }

    public void SpawnEnemy()
    {
        //Randomize the enemy spawned
        //int randomPrefabID = Random.Range(0, prefabs.Count);
        //Randomize the spawn point

        //Instantiate the enemy prefab
        GameObject spawnedEnemy = Instantiate(prefab, spawnPoint);
    }
}
