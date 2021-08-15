using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10;

    private PlayerController _playerController;
    // Start is called before the first frame update
    private void Start()
    {
        _playerController = GameObject.Find("Player")
            .GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.GameOver) // si no hemos llegado al final de la partida, sigue 
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left );
        }
        
        
        
    }
}
