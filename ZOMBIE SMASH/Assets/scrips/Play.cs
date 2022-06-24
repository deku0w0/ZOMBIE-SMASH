using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Play : MonoBehaviour
{
    public GameObject canvasInicio;
    public void play()
    {
        canvasInicio.gameObject.SetActive(false);
        SceneManager.LoadScene("Game");

    }
}
