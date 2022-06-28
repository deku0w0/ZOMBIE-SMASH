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


    [Header("spawn")]
    public GameObject[] enemies;

    public float timeSpawn = 1;

    public float repeatSpawnRate = 3;

    public Transform xRangeRight;
    public Transform xRangeLeft;
    public Transform yRangeUp;
    public Transform yRangeDown;

    [Header("control de dificultad")]
    public float curva = 10f;
    public float contador = 0f;
    int Cantidad = 2;

    [Header("sonidos")]
    public AudioSource audi;
    public AudioClip elSonido;
    public AudioClip elSonidoH;

    [Header("menuDePausa")]
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    public bool juegoPausado = false;

    void Start()
    {

        Spawn(2);



    }
    void Update()
    {

        //contador 
        tiempoDeFrameConTimeScale = Time.deltaTime * escalaDelTiempo;

        timeInsecondsToShow += tiempoDeFrameConTimeScale;

        actualizarReloj(timeInsecondsToShow);
        // spawn 
        contador += Time.deltaTime;

        if (contador >= curva)
        {
            timeSpawn = timeSpawn - 0.5f;
            repeatSpawnRate = repeatSpawnRate - 0.5f;
            contador = 0;
            // InvokeRepeating("Spawn", timeSpawn, repeatSpawnRate);
            Spawn(Cantidad);
            Cantidad += 2;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                MenuPausa();
            }
        }
    }
    public void GameOver()
    {
        gameOver.GameOver();
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
    public void Spawn(float cantidad)
    {

        Vector3 spawnnPosition = new Vector3(0, 0, 0);

        for (int i = 0; i < cantidad; i++)
        {
            spawnnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);

            GameObject enemys = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnnPosition, gameObject.transform.rotation);
        }

    }
    public void Sonido(bool isHuman)
    {
        if (isHuman == true)
        {
            AudioSource.PlayClipAtPoint(elSonidoH, gameObject.transform.position);
        }
        else
        {
           AudioSource.PlayClipAtPoint(elSonido, gameObject.transform.position);      
        }
       
    }
    public void MenuPausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
    public void Reiniciar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Cerrar()
    {
        SceneManager.LoadScene("Play");
    }

}
