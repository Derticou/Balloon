using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    GameManagerX gameManagerX;
    
    public bool gameOver = false;

    float upBound=14.5f;
    bool isLowEnough = true;
    private float floatForce = 0.8f;
    private float gravityModifier = 1.5f;
    public Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("GameManagerX").GetComponent<GameManagerX>();

        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        
        playerRb.useGravity = false;
        playerRb.isKinematic = true;


    }
    public void FirstForce()
    {
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerX.isGameActive)
        {
            playerRb.useGravity = true;
            playerRb.isKinematic = false;

            if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough)
            {
                playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
            }

            if (transform.position.y >= upBound)
            {
                isLowEnough = false;
                playerRb.AddForce(Vector3.down * floatForce, ForceMode.Impulse);
                transform.position = new Vector3(transform.position.x, upBound, transform.position.z);
            }
            if (transform.position.y <= upBound)
            {
                isLowEnough = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Destroy(other.gameObject);
            gameManagerX.gameoverScreen.SetActive(true);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            gameManagerX.MoneyAdd();

        }
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
           
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

}
