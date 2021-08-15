using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float bottomBound = -30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > topBound ) //Destruir balas
        {
            Destroy(this.gameObject);
        }   
        if (this.transform.position.z < bottomBound) //Destruir Enemigos
        {
            Debug.Log("GAME OVER");
            Destroy(this.gameObject);

            Time.timeScale = 0;
        }   
    }
}
