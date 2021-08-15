using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        inGame,gameOver
    }

    public GameState gameState;
    
    public List<GameObject> targetPrefabs;
    public List<GameObject> lives;
    
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    
    public int _score;
    public int score // para no tener puntuación negativa
    {
        set { _score = Mathf.Max(value, 0); } 
        get { return _score; }
    }
    
    public GameObject titleScreen;
    public GameObject buttonScreen;
    public InputField inputName;

    public Button saveButton;
    public Button loadButton;
    public Button restartButton;
    
    private int numberOfLifes = 4;
    
    private void Start()
    {
        ShowScore();
    }

    /// <summary>
    /// Método que inicia la partida cambiando el valor del estado del juego
    /// </summary>
    /// <param name="Número entero que indica el grado de dificultaf del juego"></param>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);
        buttonScreen.gameObject.SetActive(false);

        spawnRate /= difficulty;
        numberOfLifes -= difficulty;
        
        for (int i = 0; i < numberOfLifes; i++)
        {
            lives[i].SetActive(true);
        }
        
        StartCoroutine(SpawnTarget());
        
        score = 0;
        UpdateScore(0);
        
    }

    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int idx = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[idx]);
//            UpdateScore(5);
        }
    }
    
/// <summary>
/// Actualiza la puntuación y lo muestra por pantalla
/// </summary>
/// <param name="scoreToAdd">Número de puntos a añadir a la puntuación global</param>
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:  \n" + score;
    }


    private const string MAX_SCORE = "MAX_SCORE";    
    
    public void ShowScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE,0);
        scoreText.text = "Max Score: \n" + maxScore;
    }

/// <summary>
/// método para asignar la máxima puntuación haciendo uso de PlayerPrefs como método para almacenar 
/// </summary>
    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, score);
        }
    }
/// <summary>
/// Método de fin de partida, cada vez resta una vida, si aún quedan vidas quita un corazón, si ya no aparecen botones, input y score
/// </summary>
    public void GameOver()
    {
        numberOfLifes--;

        if (numberOfLifes >= 0)
        {
            Image heartImage = lives[numberOfLifes].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;
        }
        
        if (numberOfLifes <= 0)
        {
            SetMaxScore();
            gameOverText.gameObject.SetActive(true);
            gameState = GameState.gameOver;
            restartButton.gameObject.SetActive(true);
            inputName.gameObject.SetActive(true);
            saveButton.gameObject.SetActive(true);
            loadButton.gameObject.SetActive(true);
            
            
        }
    }
/// <summary>
/// método para volver a cargar la escena activa 
/// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
