using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    //Enemy prefabs
    [SerializeField] public List<GameObject> prefabs;

    //Enemy spawn
    [SerializeField] public Waypoints[] WaypointsLists;

    //Enemy spawn interval
    //public float spawnInterval = 5f;


    /*void Start()
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
    }*/

    public void SpawnEnemy()
    {
        //Randomize the enemy spawnPoint
        int selectedWaypontNumber = Random.Range(0, WaypointsLists.Length);

        //Instantiate the enemy prefab
        int randomPrefabID = Random.Range(0, prefabs.Count);

        GameObject spawnedEnemy =
            Instantiate(prefabs[randomPrefabID], WaypointsLists[selectedWaypontNumber].waypoints[0]);

        spawnedEnemy.GetComponent<Enemy>().SetWayponts(WaypointsLists[selectedWaypontNumber]);
    }
}