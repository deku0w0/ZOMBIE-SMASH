using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOveer : MonoBehaviour
{
    public GameObject gameOver;



    public void setUp(int life)
    {
        gameOver.SetActive(true);
    }

    private void Update()
    {
        
    }

    public void RestarButton()
    {
        SceneManager.LoadScene("Game");

    }

}
