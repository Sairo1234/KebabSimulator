using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DesplazamientoPunto : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//


    private NavMeshAgent jugador;
    private GameObject gameObjectAsignado;
    private Transform destino;
    private bool estaDesplazandose = false;


    [Header("Tag")]
    public string tagGameObject;

    [Header("Funcion a realizar")]
    public string funcionScript;



    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        gameObjectAsignado = this.gameObject;
        GameObject GameObjectdestino = GameObject.FindGameObjectWithTag(tagGameObject);
        destino = GameObjectdestino.transform;
    }

    private void Update()
    {
        if (estaDesplazandose == true)
        {
            comprobarDistacia();
        }
    }

    void OnMouseDown()
    {
        if (this.enabled)
        {
            jugador.SetDestination(destino.position);
            estaDesplazandose = true;
        }
    }

    private void comprobarDistacia()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(gameObjectAsignado.transform);
            estaDesplazandose = false;

            gameObjectAsignado.SendMessage(funcionScript, null);
        }
    }
}

