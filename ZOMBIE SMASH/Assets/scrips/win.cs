using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public void Win()
    {
        SceneManager.LoadScene("win");
    }
    private void Update()
    {


    }
    public void RestarButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void Exit()
    {
        SceneManager.LoadScene("Play");
        Time.timeScale = 1f;
    }
}
