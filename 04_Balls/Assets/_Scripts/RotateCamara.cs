using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateCamara : MonoBehaviour
{

    private float rotationSpeed = 30f;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(horizontalInput * rotationSpeed * Time.deltaTime * Vector3.up);
    }
}
