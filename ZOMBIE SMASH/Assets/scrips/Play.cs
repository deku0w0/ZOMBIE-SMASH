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
}
