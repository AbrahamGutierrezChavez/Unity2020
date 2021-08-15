using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 20;
    [Range(0,20),SerializeField,Tooltip("Grado de inclinación de la nariz")]
    private float speedInput;

    private float directionY = 90;
    [Range(0,90),SerializeField,Tooltip("Grado de inclinación de la nariz")]
    private float verticalInput;

    private float directionZ = 90;
    [Range(0, 90), SerializeField, Tooltip("Grado de inclinación en alas")]
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        speedInput = Input.GetAxis("Jump");
        
        // move the plane forward at a constant rate
        transform.Translate(speed *Vector3.forward* speedInput * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        //rotationSpeed = Input.GetAxis("")
        transform.Rotate(Vector3.left * verticalInput * Time.deltaTime * directionY);
        this.transform.Rotate(Vector3.back * horizontalInput * Time.deltaTime * directionZ );
    }
}
