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



    void Start()
    {
        InvokeRepeating("Spawn", timeSpawn, repeatSpawnRate);
    }

    public void Spawn()
    {

        Vector3 spawnnPosition = new Vector3(0, 0, 0);

        spawnnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);

        GameObject enemys = Instantiate(enemies[Random.Range(0,enemies.Length)], spawnnPosition, gameObject.transform.rotation);


    }

     private void Update()
     {




     }


}
