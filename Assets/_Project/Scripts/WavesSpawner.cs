using System.Collections;
using TMPro;
using UnityEngine;

public class WavesSpawner : MonoBehaviour
{
    //UI text for round
    public TextMeshProUGUI waveCountText;
    int roundCount;

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
            /*Debug.Log(GameObject.FindWithTag("TowerStone").GetComponent<Tower>());
            Tower towerStone = GameObject.FindWithTag("TowerStone").GetComponent<Tower>();
            Tower towerFire = GameObject.FindWithTag("TowerFire").GetComponent<Tower>();*/

            /*if (roundCount == 1)
            {
                towerStone.setTowerCost(towerStone.getTowerCost() * 2);
                towerFire.setTowerCost(towerFire.getTowerCost() * 2);
            }*/

            /*foreach (var prefabsEnemy in gameObject.GetComponent<EnemySpawner>().prefabsEnemies)
            {
                Enemy enemy = prefabsEnemy.GetComponent<Enemy>();
                if (enemy.getEnemyValue() > 10)
                {
                    enemy.setEnemyValue(enemy.getEnemyValue() - 5);
                }
            }*/

            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false;
        yield return new WaitForSeconds(15);

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