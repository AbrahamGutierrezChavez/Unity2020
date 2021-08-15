using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9;
    
    public int enemyCount;
    public int enemyWave = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyWave);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemyWave(enemyWave);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }
/// <summary>
/// Generate a random pos in the game zone
/// </summary>
/// <returns>
/// return vector3 with a random pos in the spawnRange
/// </returns>
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
/// <summary>
/// Método que genera un número determinado de enemigos en pantalla
/// </summary>
    private void SpawnEnemyWave(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        { 
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);   
        }
    }
}

