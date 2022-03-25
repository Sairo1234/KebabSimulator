using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class atenderCliente : MonoBehaviour
{
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject vista;

    private void Start()
    {
        vista.SetActive(false);
    }

    private void LateUpdate()
    {
        if (jugador.remainingDistance >= 0.001 && jugador.remainingDistance <= 0.2)
        {
            vista.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        jugador.SetDestination(destino.position);
    }
}
