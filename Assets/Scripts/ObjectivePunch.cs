using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePunch : MonoBehaviour
{
    int auxLife, multy, rand;
    bool dosGolpes;

    // Start is called before the first frame update
    void Start()
    {
        auxLife = GameManager.instance.life;
        multy = 1;

        rand = Random.Range(0, 6);

        if(rand == 1 || rand == 3)
        {
            dosGolpes = true;
        }
        else
        {
            dosGolpes = false;
        }

        dosGolpes = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cube"))
        {
            if (!dosGolpes)
            {
                // Entonces se destrulle el cubo y se suma un punto
                Destroy(this.gameObject);

                // Esto es para recompenzar al jugador en caso de que lleve muchos puntos sin morir
                if (auxLife == GameManager.instance.life)
                {
                    if (GameManager.instance.score >= 10 && GameManager.instance.score <= 14)
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
                    auxLife = GameManager.instance.life;
                }

                GameManager.instance.score++;
                GameManager.instance.score *= multy;
                GameManager.instance.destroy++;

                if (GameManager.instance.destroy >= 210)
                {
                    // game over
                    GameManager.instance.destroy = 210;
                    GameManager.instance.GameOver();
                }
            }
            else
            {
                dosGolpes = false;
            }
        }
    }
}
