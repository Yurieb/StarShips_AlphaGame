using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] rock;
    public GameObject[] enemy;
    public GameObject health;

    private float zRockSpawn = 16.0f;
    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 18.0f;
    private float zHealthRange = 8.0f;
    private float ySpawn = 0.75f;

    private float healthSpawnTime = 5.0f;
    private float enemySpawnTime = 7.0f;
    private float rockSpawnTime = 4.0f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomRock", startDelay, rockSpawnTime);
        InvokeRepeating("SpawnHealth", startDelay, healthSpawnTime);
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomRock()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, rock.Length);

        Vector3 spawnPos = new Vector3(randomX, xSpawnRange, zRockSpawn);

        Instantiate(rock[randomIndex], spawnPos, health.gameObject.transform.rotation);

    }

    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemy.Length);

        Vector3 spawnPos = new Vector3(randomX, xSpawnRange, zEnemySpawn);

        Instantiate(enemy[randomIndex], spawnPos, health.gameObject.transform.rotation);

    }
  
    void SpawnHealth()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zHealthRange, zHealthRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(health, spawnPos, health.gameObject.transform.rotation);
    }


}
