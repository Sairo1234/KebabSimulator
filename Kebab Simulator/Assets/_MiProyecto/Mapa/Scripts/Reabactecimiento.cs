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

    [Header("Estaciones")]
    public GameObject modeloEstacionCarne;
    public GameObject modeloEstacionVerdura;
    public GameObject modeloEstacionSalsa;


    ///----------------------------------------------------------------------------------------//
    //----------------------------------------- M�TODOS --------------------------------------//

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

    public void reabastecerCarne()
    {
        modeloEstacionCarne.GetComponent<A�adirCarne>().cantidad = 10;
    }

    public void reabastecerVerdura()
    {
        modeloEstacionVerdura.GetComponent<A�adirVerdura>().cantidad = 10;
    }

    public void reabastecerSalsa()
    {
        modeloEstacionSalsa.GetComponent<A�adirSalsa>().cantidad = 10;
    }


    //--------------------------------------------------------------------------//
    //------------------------- DESPLAZAMIENTO COCINA --------------------------//

    private void comprobarDistaciaAlmacen()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(puertaAlmacen.transform);
            estaReabasteciendo = false;
            reabastecerCarne();
            reabastecerSalsa();
            reabastecerVerdura();
        }
    }


}
