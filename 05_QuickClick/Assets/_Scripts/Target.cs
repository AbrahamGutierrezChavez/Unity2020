using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float minForce = 12,
        maxForce = 16,
        maxTorque = 12,
        xRange = 4,
        ySpawnPos = -6;

    private GameManager gameManager;
    
    public int pointValue;
    public ParticleSystem explosionParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse );
        _rigidbody.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
/// <summary>
/// Genera un vector aleatorio en tres dimensiones
/// </summary>
/// <returns>Fuerza aleatoria hacia arriba</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce , maxForce);
    }

/// <summary>
/// Genera un número aleatorio 
/// </summary>
/// <returns>Valor aleatorio entre -maxTorque y maxTorque</returns>
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

/// <summary>
/// Genera un vector aleatorio
/// </summary>
/// <returns>Posición aleatoria en 3D con la coordenada z = 0 </returns>
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange,xRange), ySpawnPos); 
    }
/// <summary>
/// Método para destriur objetos mediante el clickDown del mouse
/// </summary>
    private void OnMouseDown()
    {
        if (gameManager.gameState == GameManager.GameState.inGame)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position,explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
            
            if (gameObject.CompareTag("Good"))
            {
                //gameManager.UpdateScore(-5);
                gameManager.GameOver();
            }
        }
    }
}
