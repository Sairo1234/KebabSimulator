using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteraccionEstacionVerdura : MonoBehaviour
{

    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //DESPLAZAMIENTO A LA COCINA
    [Header("Desplazamiento")]
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject cocinaVerdura;
    private bool estaPreparandoKebab = false;

    //SPAWN DEL KEBAB
    [Header("Spawn Kebab")]
    public GameObject modeloKebab;
    public Transform puntoSpawn;

    //REFERENCIA AL GAMEOBJECT KEBAB DEL JUGADOR
    private GameObject kebabEnPreparacion;

    //CANTIDAD DE INGREDIENTES
    [Header("Cantidad de Verdura")]
    public int cantidadVerdura = 5;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        if (estaPreparandoKebab == true)
        {
            comprobarDistaciaCocinaVerdura();
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
        if (kebabEnPreparacion.GetComponent<Kebab>().contieneVerdura() == false)
        {
            kebabEnPreparacion.GetComponent<Kebab>().anyadirVerdura("Verdura");
            cantidadVerdura--;
            Debug.Log("Se ha añadido verdura al Kebab");
        }
        else
        {
            Debug.Log("El Kebab ya tiene verdura");
        }
    }

    //--------------------------------------------------------------------------//
    //------------------------- DESPLAZAMIENTO COCINA --------------------------//

    private void comprobarDistaciaCocinaVerdura()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(cocinaVerdura.transform);
            estaPreparandoKebab = false;
            if (cantidadVerdura != 0)
            {
                asignarKebab();
                anyadirIngredienteKebab();
            }
            else
            {
                Debug.Log("No hay verdura en la estación!");
            }
        }
    }

    //----------------------------------------------------------------------------------------//
    //----------------------------------------------------------------------------------------//
}
