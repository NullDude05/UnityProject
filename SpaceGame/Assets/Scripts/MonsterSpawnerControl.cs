using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerControl : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject[] enemies;
    int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;

	// Use this for initialization
	void Start () {
        spawnAllowed = true;
        InvokeRepeating("SpawnEnemy", 1f, 5f);
	}
	
    void SpawnEnemy()
    {
        if (spawnAllowed) {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
