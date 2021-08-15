using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultyButton : MonoBehaviour
{
    private Button _button;
    private GameManager gameManager;

    [Range(1,3)]
    public int difficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    /// <summary>
    /// Cambiará la dificultad del juego en 3 botones
    /// </summary>
    void SetDifficulty()
    {
        Debug.Log("El botón "+ gameObject.name + " ha sido pulsado");
        gameManager.StartGame(difficulty);
    }
}
