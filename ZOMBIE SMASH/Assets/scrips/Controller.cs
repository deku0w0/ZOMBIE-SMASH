using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float velocidadMove;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distancia;
    private SpriteRenderer spriteRender;
    private int siguientePaso = 0;
    public GameObject enemy;
    public life Life;

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePaso].position, velocidadMove * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimiento[siguientePaso].position) < distancia)
        {
            siguientePaso += 1;

            if (siguientePaso >= puntosMovimiento.Length)
            {
                gameObject.SetActive(false);
            }
        }
    }



    private void OnBecameInvisible()
    {
        Life--;

        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
