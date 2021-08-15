using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollitions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            //El animal choca contra un proyectil
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            
        }
        
    }
}
