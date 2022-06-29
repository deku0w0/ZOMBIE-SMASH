using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControllerEnemys : MonoBehaviour
{

    [Header("movimiento")]
    public float velocidadMove;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distancia;
    private int siguientePaso = 0;

    [Header("damage")]
    public bool isHuman;
    public int points;


    public GameObject[] sprites;
    public int damage;
    int actualDamage;

    public GameManager PlayerLife;

    private void Start()
    {
        PlayerLife = FindObjectOfType<GameManager>();

        velocidadMove = Random.Range(2,6);
        damage = Random.Range(1,3);
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
        if (isHuman && actualDamage >= damage)
        {
            PlayerLife.Life--;
            PlayerLife.heart();
        }

        if (PlayerLife.Life == 0)
        {
            PlayerLife.GameOver();
        }

        if (actualDamage >= damage)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;

            PlayerLife.Score(points);
            velocidadMove = 0;
            sprites[0].SetActive(false);
            sprites[1].SetActive(true);

            if (sprites[1] == true)
            {
                Destroy(gameObject, 0.6f);
            }

            PlayerLife.Sonido(isHuman);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.tag == "Enemy" && collision)
        {
            PlayerLife.Life--;
            PlayerLife.heart();
            Destroy(gameObject);
        }

        if (PlayerLife.Life ==0)
        {
            PlayerLife.GameOver();
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
