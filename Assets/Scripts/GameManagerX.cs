using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    PlayerControllerX playerControllerX;
    public Rigidbody playerRb;
    public Button startGame, restartGame;

    public GameObject startScreen, pauseScreen, gameoverScreen;

    public bool isGameActive, isGamePause;

    public TextMeshProUGUI moneyText;
    int money = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerX = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        
        isGameActive = false;
        isGamePause = false;


        startScreen.SetActive(true);
        gameoverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }
    private void Update()
    {
        //Pause Game
        if (isGameActive && Input.GetKeyDown(KeyCode.P) && !startScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(true);
            isGameActive = false;
            Time.timeScale = 0;
        }
        //Unpause Game
        else if (!isGameActive && Input.GetKeyDown(KeyCode.P) && !startScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(false);
            isGameActive = true;
            Time.timeScale = 1;
        }
    }
    public void StartGame()
    {
        isGameActive = true;
        startScreen.SetActive(false);
        playerControllerX.FirstForce();
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GameOver(bool gameOver)
    {
        if (gameOver)
        {
            isGameActive = false;
            gameoverScreen.SetActive(true);
        }

    }
    public void MoneyAdd()
    {
        money++;
        moneyText.text = money.ToString();
    }

}
