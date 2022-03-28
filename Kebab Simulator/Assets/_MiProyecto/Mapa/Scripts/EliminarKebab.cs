using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EliminarKebab : MonoBehaviour
{
    //MOVIMIENTO A LA COCINA
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject papelera;
    public bool estaPreparandoKebab = false;

    //TIRAR KEBAB
    public GameObject kebabParaTirar;
    public Transform LocalizacionKebab;

    private void Update()
    {
        if (estaPreparandoKebab == true)
        {
            comprobarDistaciaPapelera();
        }

    }
    private void OnMouseDown()
    {
        jugador.SetDestination(destino.position);
        estaPreparandoKebab = true;
    }

    public void eliminarKebab()
    {
        if (LocalizacionKebab.childCount != 0)
        {
            kebabParaTirar = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            Destroy(kebabParaTirar);
            Debug.Log("Se ha tirado el kebab");
        }
        else
        {
            Debug.Log("No hay ningun kebab para tirar");
        }
    }

    private void comprobarDistaciaPapelera()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(papelera.transform);
            estaPreparandoKebab = false;
            eliminarKebab();
        }
    }
}



