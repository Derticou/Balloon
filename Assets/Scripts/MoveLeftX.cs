using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    private float speed = 15;
    private PlayerControllerX playerControllerScript;
    private float leftBound = -15;
    GameManagerX gameManager;

    // Start is called before the first frame update
    void Start()
    {   
        gameManager=GameObject.Find("GameManagerX").GetComponent<GameManagerX>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            // If game is not over, move to the left
            if (playerControllerScript.gameOver == false)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }

            // If object goes off screen that is NOT the background, destroy it
            if (transform.position.x < leftBound && (gameObject.CompareTag("Bomb") || gameObject.CompareTag("Money")))
            {
                Destroy(gameObject);
            }
        }


    }
}
