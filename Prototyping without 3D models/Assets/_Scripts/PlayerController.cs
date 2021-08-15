using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody _rigidbody;
    private float verticalInput, horizontalInput;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        //_rigidbody.AddForce( speed * Time.deltaTime * verticalInput * Vector3.forward , ForceMode.Force);
        //_rigidbody.AddTorque( speed * Time.deltaTime * horizontalInput * Vector3.up , ForceMode.Force);
        
        //si se utiliza física se usa AddForce sobre el rigidBody
        // AddTorque sobre el RigidBody
        
        //Si no se usa física, se usa translate sobre el transform
        // rotate sobre el transform -> para rotar 

        transform.Translate(speed * Time.deltaTime * verticalInput * Vector3.forward);
        transform.Rotate(speed * Time.deltaTime * horizontalInput * Vector3.up);
        
        if (Mathf.Abs(transform.position.x) >= 9 || Mathf.Abs(transform.position.z) >= 9)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        
    }
    
}
