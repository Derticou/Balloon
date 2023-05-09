using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    GameManagerX gameManagerX;

    
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1f;

    private PlayerControllerX playerControllerXScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("GameManagerX").GetComponent<GameManagerX>();

        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerXScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
        if (gameManagerX.isGameActive)
        {
            // Set random spawn location and random object index
            Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
            int index = Random.Range(0, objectPrefabs.Length);

            // If game is still active, spawn new object
            if (!playerControllerXScript.gameOver)
            {
                Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
            }
        }


    }
}
