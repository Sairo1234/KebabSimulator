using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntradaCliente : MonoBehaviour
{

    public Transform[] puntos;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(puntos[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(puntos[0].position);
    }
}
