using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPCS : MonoBehaviour
{
    [Header("GameObjects de la escena")]
    public GameObject cliente;
    public Transform puntoSpawn1;
    public Transform puntoSpawn2;
    public Transform puntoSpawn3;


    public float next_spawn_time;

    public float Cronometro = 0;
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time+1;
        spawnCliente();
    }

    // Update is called once per frame
    void Update()
    {
        Cronometro = Time.time - startTime;
        if (Cronometro > next_spawn_time)
        {
            spawnCliente();

        }
    }
    //This function has to instantiate cliente in puntoSpawn.transform every 5 to 10 seconds
    public void spawnCliente()
    {
        Instantiate(cliente, puntoSpawn1.transform);
        Instantiate(cliente, puntoSpawn2.transform);
        Instantiate(cliente, puntoSpawn3.transform);
        next_spawn_time += Random.Range(5.0f, 10.0f);
    }
}
