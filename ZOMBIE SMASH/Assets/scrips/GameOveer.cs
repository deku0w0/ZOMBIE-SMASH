using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOveer : MonoBehaviour
{

    private void Start()
    {

    }
    public void GameOver()
    {
        SceneManager.LoadScene("gameover");
    }
    private void Update()
    {


    }
    public void RestarButton()
    {
        SceneManager.LoadScene("Game");
    }

}
