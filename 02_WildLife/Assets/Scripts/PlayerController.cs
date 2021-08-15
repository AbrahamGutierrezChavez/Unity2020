using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;

    public float xRange = 15.0f;

    public GameObject projectilePreFab; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // MOVIMIENTO DEL PERSONAJE
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (transform.position.x < - xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        // ACCIONES DEL PERSONAJE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Si entramos aquí, hay que lanzar un proyectil
            Instantiate(projectilePreFab, transform.position, projectilePreFab.transform.rotation);
        }

        
    }
}
