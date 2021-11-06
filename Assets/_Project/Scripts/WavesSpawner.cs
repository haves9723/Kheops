using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WavesSpawner : MonoBehaviour
{
    //UI text for round
    public TextMeshProUGUI waveCountText;
    int roundCount = 0;

    public float spawnRate = 1f;
    public float timeBetweenWaves = 10f;

    public int enemyCount;

    public int enemiesLeft;

    bool waveIsDone = true;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        //enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        waveCountText.text = "Round : " + roundCount.ToString();
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Debug.Log(enemiesLeft);
        if (waveIsDone == true && enemiesLeft == 0)
        {
            roundCount += 1;
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false;
        //yield return new WaitForSeconds(30);

        for (int i = 0; i < enemyCount; i++)
        {
            GetComponent<EnemySpawner>().SpawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }

        if (spawnRate > .5f)
        {
            
            spawnRate -= .5f;
        }


        enemyCount += 3;

        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true;
    }
}