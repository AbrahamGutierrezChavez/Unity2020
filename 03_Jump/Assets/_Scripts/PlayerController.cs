using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    const string SPEED_MULTIPLAYER = "Speed Multiplayer";
    private const string JUMP_TRIGER = "Jump_trig";
    private const string SPEED_F = "Speed_f";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";

    private Rigidbody _playerRb;
    public float jumpForce;
    public float gravityMultiplayer;
    public bool isOnGround = true;
    private bool _gameOver = false;
    public bool GameOver { get => _gameOver; }

    private Animator _animator;

    public ParticleSystem explosion, dirt;
    
    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    [Range(0,1)]
    public float audioVolume = 1;

    private float speedMultiplayer =1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplayer *new Vector3(0,-9.81f,0); // Physics.gravity = Physics.gravity * gravityMultiplayer;
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F,1);
        _audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplayer += Time.deltaTime/10;
        _animator.SetFloat(SPEED_MULTIPLAYER,speedMultiplayer);
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround==true  && !GameOver) // ==comparar
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //F / m*a    
            isOnGround = false; // = asignar
            _animator.SetTrigger(JUMP_TRIGER);
            dirt.Stop();
            _audioSource.PlayOneShot(jumpSound,audioVolume);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !GameOver)
        {
            isOnGround = true;
            dirt.Play();
        } else if (other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            dirt.Stop();    
            explosion.Play();            
            _animator.SetBool(DEATH_B , true);
            _animator.SetInteger(DEATH_TYPE_INT,Random.Range(1,3));
            _audioSource.PlayOneShot(crashSound,audioVolume);
            Invoke("RestartGame",1.0f);
        }
        
    }
    void RestartGame()
    {
        
        speedMultiplayer = 1;
        SceneManager.LoadScene("Scenes/Prototype 3", LoadSceneMode.Single); 
    }
}
