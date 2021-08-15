using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCilinder : MonoBehaviour
{
    private float speedRotation = 60;

    private float translateSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += translateSpeed * Time.deltaTime *Vector3.left;
        transform.Rotate( speedRotation * Time.deltaTime *Vector3.up);
        
        //this.transform.Translate(Vector3.left * Time.deltaTime * translateSpeed);
    }

}
