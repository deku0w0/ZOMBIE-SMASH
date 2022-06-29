using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Play : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Game");
    }
    public void reglas()
    {
        SceneManager.LoadScene("reglas");
    }
    public void Exit()
    {
        SceneManager.LoadScene("Play");
        Time.timeScale = 1f;
    }
    public void exit2()
    {

        Application.Quit();
    }
}
