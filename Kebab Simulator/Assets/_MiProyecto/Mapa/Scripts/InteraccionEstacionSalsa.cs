using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteraccionEstacionSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //DESPLAZAMIENTO A LA COCINA
    [Header("Desplazamiento")]
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject cocinaSalsa;
    private bool estaPreparandoKebab = false;

    //SPAWN DEL KEBAB
    [Header("Spawn Kebab")]
    public GameObject modeloKebab;
    public Transform puntoSpawn;

    //REFERENCIA AL GAMEOBJECT KEBAB DEL JUGADOR
    private GameObject kebabEnPreparacion;

    //CANTIDAD DE INGREDIENTES
    [Header("Cantidad de Salsa")]
    public int cantidadSalsa = 5;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

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

    //--------------------------------------------------------------------------//
    //----------------------------- PREPARAR KEBAB -----------------------------//

    public void asignarKebab()
    {
        if (puntoSpawn.childCount == 0)
        {
            spawnKebabEnPlato();
        }
        else
        {
            kebabEnPreparacion = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            cantidadSalsa--;
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

    //--------------------------------------------------------------------------//
    //------------------------- DESPLAZAMIENTO COCINA --------------------------//

    private void comprobarDistaciaCocinaSalsa()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(cocinaSalsa.transform);
            estaPreparandoKebab = false;

            if (cantidadSalsa != 0)
            {
                asignarKebab();
                anyadirIngredienteKebab();
            }
            else
            {
                Debug.Log("No hay salsa en la estación!");
            }
        }
    }

    //----------------------------------------------------------------------------------------//
    //----------------------------------------------------------------------------------------//
}

