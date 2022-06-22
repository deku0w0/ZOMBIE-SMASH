using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOveer : MonoBehaviour
{
    public GameObject gameOver;
    public PlayerStadistics player;
    public GameObject canvasInicio;

    private void Start()
    {
    }

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

    public void play()
    {

        Debug.Log("play");
        canvasInicio.gameObject.SetActive(false);
        SceneManager.LoadScene("Game");

    }

}
