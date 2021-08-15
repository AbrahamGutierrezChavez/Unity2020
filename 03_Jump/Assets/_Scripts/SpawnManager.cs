using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos;// = new Vector3(40, 0, 0); 

    private float startDelay = 2;
    private float repeatRate = 2;



    private PlayerController _playerController;
    void Start()
    {
        
     InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
     _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (!_playerController.GameOver)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        
            spawnPos = this.transform.position;
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        

    }
}
