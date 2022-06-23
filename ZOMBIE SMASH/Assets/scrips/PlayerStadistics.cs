using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStadistics : MonoBehaviour
{
    [Header("player")]
    public GameObject[] Heart;
    public int Life = 3;
    public GameOveer gameOver;


    private void GameOver()
    {
        if (Life <= 0)
        {
            gameOver.setUp(Life);

        }

    }

    private void Update()
    {
        GameOver();

        if (Life<1)
        {
            Destroy(Heart[1].gameObject);
        }
        else if (Life < 2)
        {
            Destroy(Heart[2].gameObject);
        }
       else if (Life < 3)
        {
            Destroy(Heart[0].gameObject);
        }



    }

}
