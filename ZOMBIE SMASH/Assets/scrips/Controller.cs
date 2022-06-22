using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [Header ("movimiento")]
    public float velocidadMove;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distancia;
    private int siguientePaso = 0;

    [Header ("damage")]
    public bool isHuman;

    public int damage;
    int actualDamage;

    public PlayerStadistics PlayerLife;

    [Header("songs")]
    public Sonidos song;

   
   

    private void Start()
    {
        PlayerLife = FindObjectOfType<PlayerStadistics>();
    }
    private void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePaso].position, velocidadMove * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimiento[siguientePaso].position) < distancia)
        {
            siguientePaso += 1;

            if (siguientePaso >= puntosMovimiento.Length)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        move();

    }



    private void OnMouseDown()
    {
        actualDamage++;

        if (isHuman)
        {
            PlayerLife.Life--;
        }

        if (actualDamage >= damage)
        { 
            Destroy(gameObject);
            song.Sonido();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.tag == "Enemy" && collision)
        {
            PlayerLife.Life--;
            Destroy(gameObject);
        }
    }

   private void OnBecameInvisible()
    {

        if (isHuman)
        {
            Destroy(gameObject);
        }
        
    }
}
