using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteraccionEstacionSalsa : MonoBehaviour
{
    //MOVIMIENTO A LA COCINA
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject cocinaSalsa;
    public bool estaPreparandoKebab = false;

    //SPAWN DEL KEBAB
    public GameObject modeloKebab;
    public Transform puntoSpawn;

    //GAMEOBJECT KEBAB
    public GameObject kebabEnPreparacion;

    private void Update()
    {
        if (estaPreparandoKebab == true)
        {
            comprobarDistaciaCocinaSalsa();
        }

    }

    void OnMouseDown()
    {
        jugador.SetDestination(destino.position);
        estaPreparandoKebab = true;
    }

    public void asignarKebab()
    {
        if (puntoSpawn.childCount == 0)
        {
            spawnKebabEnPlato();
        }
        else
        {
            kebabEnPreparacion = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            Debug.Log("Ya hay un kebab");
        }
    }

    public void spawnKebabEnPlato()
    {
        GameObject NuevoKebabEnPreparacion = Instantiate(modeloKebab, puntoSpawn);
        NuevoKebabEnPreparacion.tag = "KebabEnPreparacion";
        kebabEnPreparacion = NuevoKebabEnPreparacion;
        Debug.Log("Kebab spawneado");
    }

    public void anyadirIngredienteKebab()
    {
        if (kebabEnPreparacion.GetComponent<Kebab>().contieneSalsa() == false)
        {
            kebabEnPreparacion.GetComponent<Kebab>().anyadirSalsa("Salsa");
            Debug.Log("Se ha añadido salsa al Kebab");
        }
        else
        {
            Debug.Log("El Kebab ya tiene salsa");
        }
    }
    private void comprobarDistaciaCocinaSalsa()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(cocinaSalsa.transform);
            estaPreparandoKebab = false;
            asignarKebab();
            anyadirIngredienteKebab();
        }
    }
}

