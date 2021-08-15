using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //PROPIEDADES / VARIABLES / CAMPOS
    
    // [HideInInspector]
    [Range(0,20),SerializeField,Tooltip("velocidad actual del coche")]
    private float speed = 5.0f;

   [Range(0,25), HideInInspector, Tooltip("Velocidad del giro de coche")]
    private float turnSpeed = 20f;
    
    private float horizontalInput, verticalInput;

    // Update is called once per frame
    void Update()
    {
      // Tenemos que mover el vehículo hacia adelante. 
      /* Ecuación física    
        Movimiento rectinilíneo 
        S = s0 + V * t * (dirección)
        S = V * t
       */

      horizontalInput = Input.GetAxis("Horizontal");
      verticalInput = Input.GetAxis("Vertical");
      
      this.transform.Translate(speed*Time.deltaTime*Vector3.forward*verticalInput); // 0,1,1
      this.transform.Rotate(turnSpeed * Time.deltaTime*Vector3.up*horizontalInput);
      
      
    }
    
    
    
}
