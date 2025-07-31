using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class WaveSpawning : MonoBehaviour
{
    public List<GameObject> enemies;
    public float waveStartTime;
    public float waveEndTime;
    public float spawnRate;
    public float verticalSpawnRange;
    public float horizontalSpawnRange;

    public GameObject enemy;

    public int currentEnemy = 0;

    public List<Enemies> enemiesToSpawn;
    public enum Enemies
    {
        enemy,
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNextEnemy", waveStartTime, spawnRate);
        Invoke("CancelInvoke", waveEndTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnNextEnemy()
    {
        Instantiate(enemies[currentEnemy], new Vector3(transform.position.x + Random.Range(-horizontalSpawnRange, horizontalSpawnRange), transform.position.y + Random.Range(-verticalSpawnRange,verticalSpawnRange), 0), transform.rotation);
        currentEnemy++;

        if(currentEnemy >= enemies.Count) 
        {
            currentEnemy = 0;
        }
    }
}
