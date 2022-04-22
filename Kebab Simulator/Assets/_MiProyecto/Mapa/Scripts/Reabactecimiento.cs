using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Reabactecimiento : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //DESPLAZAMIENTO AL ALMACEN
    [Header("Desplazamiento")]
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject puertaAlmacen;
    private bool estaReabasteciendo = false;

    [Header("Ingredientes")]
    public GameObject[] ingredientes;


    ///----------------------------------------------------------------------------------------//
    //----------------------------------------- M�TODOS --------------------------------------//

    private void Start()
    {
        ingredientes = GameObject.FindGameObjectsWithTag("Ingrediente");
    }

    private void Update()
    {
        if (estaReabasteciendo == true)
        {
            comprobarDistaciaAlmacen();
        }
    }

    void OnMouseDown()
    {
        jugador.SetDestination(destino.position);
        estaReabasteciendo = true;
    }

    //--------------------------------------------------------------------------//
    //------------------------------- REABASTECER ------------------------------//

    public void reabastecerIngredientes()
    {
        for(int i=0; i<= ingredientes.Length-1; i++)
        {
            if (ingredientes[i].GetComponent<A�adirCarne>()) ingredientes[i].GetComponent<A�adirCarne>().cantidad = 10;
            else if (ingredientes[i].GetComponent<A�adirVerdura>()) ingredientes[i].GetComponent<A�adirVerdura>().cantidad = 10;
            else if (ingredientes[i].GetComponent<A�adirSalsa>()) ingredientes[i].GetComponent<A�adirSalsa>().cantidad = 10;
        }
    }


    //--------------------------------------------------------------------------//
    //------------------------- DESPLAZAMIENTO COCINA --------------------------//

    private void comprobarDistaciaAlmacen()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(puertaAlmacen.transform);
            estaReabasteciendo = false;
            reabastecerIngredientes();
        }
    }


}
