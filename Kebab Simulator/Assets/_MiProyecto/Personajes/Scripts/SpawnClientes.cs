using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClientes : MonoBehaviour
{
    float next_spawn_time;
    public GameObject cliente;
    private GameObject[] getCount;

    //public Transform puntoSpawnCliente;
    

    // Start is called before the first frame update
    void Start()
    {
        next_spawn_time = Time.time + 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("Cliente");
        if (Time.time > next_spawn_time && getCount.Length<15)
        {
            //do stuff here (like instantiate)
            Instantiate(cliente, this.gameObject.transform);

         //increment next_spawn_time
            next_spawn_time += 5.0f;
        }
    }
}
