using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("time")]
    public float tiemoiInicial;
    [Range(-10f, 10f)]
    public float escalaDelTiempo = 1;
    public TMP_Text myText;
    private float tiempoDeFrameConTimeScale = 0f;
    private float timeInsecondsToShow = 0f;
    private float escalaDeTiempoInicial;

    [Header("score")]
    public static int scoreValue = 0;
    public TMP_Text score;
    private string scoreEnPantalla;

    [Header("player")]
    public GameObject[] Heart;
    public int Life = 3;
    public GameOveer gameOver;

    void Start()
    {

        


    }
    void Update()
    {

        tiempoDeFrameConTimeScale = Time.deltaTime * escalaDelTiempo;

        timeInsecondsToShow += tiempoDeFrameConTimeScale;

        actualizarReloj(timeInsecondsToShow);
    }
    public void GameOver()
    {
        if (Life <= 0)
        {
            gameOver.setUp(Life);

        }
    }
    public void actualizarReloj(float tiempoEnSegundos)
    {
        int minutos = 0;
        int segundos = 0;
        string textoDeReloj;
        // asegurar que el tiempo no sea negativo
        if (tiempoEnSegundos < 0)
        {
            tiempoEnSegundos = 0;
        }

        //calcular minutos y segundos 
        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        //crear la cadena de caracteres con 2 digitos para los minutos y segundos 
        textoDeReloj = minutos.ToString("00") + ":" + segundos.ToString("00");

        //actualizar el elemento de text ui con la cadena de caracteres 
        myText.text = textoDeReloj;

    }
    public void heart()
    {

        if (Life < 1)
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
    public void Score(int points)
    {

        scoreValue += points;
        scoreEnPantalla = "Score" + ":" + scoreValue;
        score.text = scoreEnPantalla;
    }
}
