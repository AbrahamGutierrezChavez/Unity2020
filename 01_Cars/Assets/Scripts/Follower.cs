using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Follower : MonoBehaviour
{
    public GameObject player;

    public Vector3 offset = new Vector3(0, 5, -7);
    

    private void Update()
    {
        this.transform.position = player.transform.position + offset;
    }
    
}
