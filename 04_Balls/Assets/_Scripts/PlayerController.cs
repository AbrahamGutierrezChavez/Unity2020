using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveForce;
    
    //public GameObject focalPoint; 
    private GameObject focalPoint;
    
    public bool hasPowerUp;
    public float powerUpForce;
    public float powerUpTime;
    public GameObject[] powerUpIndicators;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwarInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(moveForce * forwarInput * focalPoint.transform.forward, ForceMode.Force);

        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position;
        }

        if (this.transform.position.y < -10)
        {
            SceneManager.LoadScene("Scenes/Prototype 4");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            
            StartCoroutine(PowerUpCountDown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;
            
            enemyRigidBody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDown()
    {
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime/powerUpIndicators.Length);
            indicator.gameObject.SetActive(false);
        }
        /*for (int i = 0; i < powerUpIndicators.Length; i++)
        {
            powerUpIndicators[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime/powerUpIndicators.Length);
            powerUpIndicators[i].gameObject.SetActive(false);    
        }
        */
        hasPowerUp = false;
        
        
    }
    
}
