using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public static SpawnBall instance;
    public Rigidbody2D ballRigid;
    public Transform spawn, player;
    public float speed;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(speed == 0)
        {
            speed = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cube"))
        {
            GameManager.instance.life--;
            HoldBall();
            LaunchBall();
        }
    }

    public void HoldBall()
    {
        ballRigid.gravityScale = 0;
        ballRigid.velocity = Vector3.zero;
        ballRigid.transform.position = spawn.transform.position;
    }

    public void LaunchBall()
    {
        // Ahora se manda la pelota hacia el player
        ballRigid.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        ballRigid.gravityScale = 1;
    }
}
