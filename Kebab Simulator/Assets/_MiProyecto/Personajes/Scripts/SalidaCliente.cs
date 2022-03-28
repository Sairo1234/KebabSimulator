using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SalidaCliente : MonoBehaviour
{

    public Transform destino;

    NavMeshAgent agent;

    public GameObject parentObject;

    public GameObject cliente;
    public Transform puntoSpawn;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destino.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance == 0)
        {
            GameObject NuevoCliente = Instantiate(parentObject);
            Destroy(parentObject);
            
        }

    }

    private void OnEnable()
    {
        agent.SetDestination(destino.position);
    }

}
