using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaPlayer : MonoBehaviour
{
    Rigidbody2D playerRb;
    public float speed;

    // Por cada 10 bloques en cadena, se vaya multiplicando por 3

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();   
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
