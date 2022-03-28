using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteraccionEstacionCarne : MonoBehaviour
{

    //MOVIMIENTO A LA COCINA
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject cocinaCarne;
    public bool estaPreparandoKebab = false;

    //SPAWN DEL KEBAB
    public GameObject modeloKebab;
    public Transform puntoSpawn;

    //REFERENCIA AL GAMEOBJECT KEBAB 
    public GameObject kebabEnPreparacion;


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
            Debug.Log("Se ha añadido carne al Kebab");
        }
        else
        {
            Debug.Log("El Kebab ya tiene carne");
        }
    }

    private void comprobarDistaciaCocinaCarne()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(cocinaCarne.transform);
            estaPreparandoKebab = false;
            asignarKebab();
            anyadirIngredienteKebab();
        }
    }
}
