using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStadistics : MonoBehaviour
{
    [Header("player")]
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
    }

}
