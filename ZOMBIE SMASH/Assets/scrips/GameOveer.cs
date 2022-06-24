using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOveer : MonoBehaviour
{
    public GameObject gameOver;
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
        Debug.Log("restart");
    }

}
