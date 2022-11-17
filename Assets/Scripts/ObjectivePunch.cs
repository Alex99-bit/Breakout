using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePunch : MonoBehaviour
{
    int auxLife, multy;

    // Start is called before the first frame update
    void Start()
    {
        auxLife = GameManager.instance.life;
        multy = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cube"))
        {
            // Entonces se destrulle el cubo y se suma un punto
            Destroy(this.gameObject);

            // Esto es para recompenzar al jugador en caso de que lleve muchos puntos sin morir
            if (auxLife == GameManager.instance.life)
            {
                if (GameManager.instance.score >= 10 && GameManager.instance.score <=14)
                {
                    multy = 2;
                }
                else if (GameManager.instance.score >= 15)
                {
                    multy = 4;
                }
            }
            else
            {
                multy = 1;
            }

            GameManager.instance.score++;
            GameManager.instance.score *= multy;

            auxLife = GameManager.instance.life;
        }
    }
}
