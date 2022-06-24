using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] enemies;

    public float timeSpawn = 1;

    public float repeatSpawnRate = 3;

    public Transform xRangeRight;
    public Transform xRangeLeft;
    public Transform yRangeUp;
    public Transform yRangeDown;

    [Header("dificultad")]
    public float curva = 10f;
    public float contador = 0f;
    int Cantidad = 2;

    void Start()
    {
        Spawn(2);
    }
     private void Update()
     {

            contador += Time.deltaTime;

            if (contador >= curva)
            {
                timeSpawn= timeSpawn - 0.5f;
                repeatSpawnRate = repeatSpawnRate - 0.5f;
                contador = 0;
            // InvokeRepeating("Spawn", timeSpawn, repeatSpawnRate);
                Spawn(Cantidad);
                Cantidad += 2;
              
            }
       

     }
    public void Spawn(float cantidad)
    {

        Vector3 spawnnPosition = new Vector3(0, 0, 0);

        for (int i = 0; i < cantidad; i++)
        {
            spawnnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);

            GameObject enemys = Instantiate(enemies[Random.Range(0,enemies.Length)], spawnnPosition, gameObject.transform.rotation);
        }

    }

    


}
