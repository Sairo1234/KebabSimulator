using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteraccionEstacionCarne : MonoBehaviour
{

    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //DESPLAZAMIENTO A LA COCINA
    [Header("Desplazamiento")]
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject cocinaCarne;
    private bool estaPreparandoKebab = false;

    //SPAWN DEL KEBAB
    [Header("Spawn Kebab")]
    public GameObject modeloKebab;
    public Transform puntoSpawn;

    //REFERENCIA AL GAMEOBJECT KEBAB DEL JUGADOR
    private GameObject kebabEnPreparacion;

    //CANTIDAD DE INGREDIENTES
    [Header("Cantidad de Carne")]
    public int cantidadCarne = 5;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        if (estaPreparandoKebab == true)
        {
            comprobarDistaciaCocinaCarne();
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
        if (kebabEnPreparacion.GetComponent<Kebab>().contieneCarne() == false)
        {
            kebabEnPreparacion.GetComponent<Kebab>().anyadirCarne("Carne");
            cantidadCarne--;
            Debug.Log("Se ha añadido carne al Kebab");
        }
        else
        {
            Debug.Log("El Kebab ya tiene carne");
        }
    }

    //--------------------------------------------------------------------------//
    //------------------------- DESPLAZAMIENTO COCINA --------------------------//

    private void comprobarDistaciaCocinaCarne()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(cocinaCarne.transform);
            estaPreparandoKebab = false;

            if(cantidadCarne != 0)
            {
                asignarKebab();
                anyadirIngredienteKebab();
            }
            else
            {
                Debug.Log("No hay carne en la estación!");
            }
            
        }
    }

    //----------------------------------------------------------------------------------------//
    //----------------------------------------------------------------------------------------//
}
