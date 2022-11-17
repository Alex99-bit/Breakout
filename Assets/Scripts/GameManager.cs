using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameStates currentGameState;
    public int score, life, destroy, auxLife;
    public TextMeshProUGUI tScore, tLife, gameOverScore;
    public GameObject pantallaStart, pantallaPause, pantallaGameOver, scene, cube;
    public Transform transformSpawn;
    public Rigidbody2D rbSpawn;
    public bool startPlay;

    //SpawnBall spawnBall;
    // [SerializeField] GameObject transformSpawn;

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
        //Destroy(scene);
        score = 0;
        destroy = 0;
        if(life == 0)
        {
            life = 5;
        }

        auxLife = life;

        SpawnBall.instance.HoldBall();
        //startPlay = false;
        //GenCube();
        //GenScecene();
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

        if (startPlay)
        {
            startPlay = false;
            GenScecene();
            SpawnBall.instance.LaunchBall();
        }

    }

    public void GameOver()
    {
        SetNewGameState(GameStates.gameOver);
    }

    public void StartGame()
    {
        SetNewGameState(GameStates.inGame);
    }

    public void SetStart()
    {
        SetNewGameState(GameStates.start);
    }

    /*public void GenCube()
    {
        for(double i = transformSpawn.transform.position.x; i <= 8.5f; i += 0.5)
        {
            transformSpawn.transform = new Vector2((float)i, transformSpawn.transform.position.y);
            Instantiate(cube, transformSpawn.transform);
        }

        /*for (transformSpawn.position.x = -8.5f; transformSpawn.position.x <= 8.5f; transform.position.x += 0.5)
        {
            Instantiate(cube, transformSpawn);
        }
    }*/

    public void GenScecene()
    {
        Instantiate(scene, transformSpawn);
        /*for (double i = rbSpawn.position.y; i <= 0.0f; i -=0.5f)
        {
            for (double j = rbSpawn.position.x; j <= 8.5f; j += 0.5)
            {
                rbSpawn.position = new Vector2((float)j, (float)i);
                Instantiate(cube, transformSpawn);
            }
        }*/
    }

    public void GameExit()
    {
        Application.Quit();
    }

    void SetNewGameState(GameStates newGameState)
    {
        switch (newGameState)
        {
            case GameStates.start:
                startPlay = true;
                Time.timeScale = 0;
                pantallaGameOver.active = false;
                pantallaPause.active = false;
                pantallaStart.active = true;
                life = auxLife;
                score = 0;
                SpawnBall.instance.HoldBall();
                //Destroy(scene);
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
                gameOverScore.text = "Your score: " + score;
                Destroy(scene);
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