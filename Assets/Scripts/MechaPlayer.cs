using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaPlayer : MonoBehaviour
{
    public static MechaPlayer instance;
    Rigidbody2D playerRb;
    public float speed;
    public Transform playerTransform;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    // Por cada 10 bloques en cadena, se vaya multiplicando por 3

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();   
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentGameState == GameStates.inGame)
        {
            playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
        }
    }
}
