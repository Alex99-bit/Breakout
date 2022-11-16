using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameStates currentGameState;
    public int score, life;
    public TextMeshProUGUI tScore, tLife;
    public GameObject pantallaStart, pantallaPause, pantallaGameOver;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        tScore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        tLife = GameObject.Find("Life").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        if(life == 0)
        {
            life = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        tScore.text = "Score: " + score;
        tLife.text = "Life: " + life;

        if (currentGameState == GameStates.inGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Entra en modo pausa
                SetNewGameState(GameStates.pause);
                print("pausa");
            }
        }
        else if(currentGameState == GameStates.pause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Se quita la pausa
                SetNewGameState(GameStates.inGame);
                print("no pausa");
            }
        }

        if(life <= 0)
        {
            life = 0;
            GameOver();
        }

    }

    void GameOver()
    {
        SetNewGameState(GameStates.gameOver);
    }

    public void StartGame()
    {
        SetNewGameState(GameStates.inGame);
    }

    void SetNewGameState(GameStates newGameState)
    {
        switch (newGameState)
        {
            case GameStates.start:
                Time.timeScale = 0;
                pantallaGameOver.active = false;
                pantallaPause.active = false;
                pantallaStart.active = true;
                break;

            case GameStates.inGame:
                pantallaPause.active = false;
                pantallaStart.active = false;
                pantallaGameOver.active = false;
                Time.timeScale = 1;
                break;

            case GameStates.pause:
                Time.timeScale = 0;
                pantallaPause.active = true;
                break;

            case GameStates.gameOver:
                Time.timeScale = 0;
                pantallaStart.active = false;
                pantallaPause.active = false;
                pantallaGameOver.active = true;
                break;
        }

        currentGameState = newGameState;
    }
}

public enum GameStates
{
    start,
    inGame,
    pause,
    gameOver
}