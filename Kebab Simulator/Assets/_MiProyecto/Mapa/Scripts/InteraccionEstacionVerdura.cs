using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteraccionEstacionVerdura : MonoBehaviour
{
    //MOVIMIENTO A LA COCINA
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject cocinaVerdura;
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
            comprobarDistaciaCocinaVerdura();
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
        if (kebabEnPreparacion.GetComponent<Kebab>().contieneVerdura() == false)
        {
            kebabEnPreparacion.GetComponent<Kebab>().anyadirVerdura("Verdura");
            Debug.Log("Se ha añadido verdura al Kebab");
        }
        else
        {
            Debug.Log("El Kebab ya tiene verdura");
        }
    }

    private void comprobarDistaciaCocinaVerdura()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(cocinaVerdura.transform);
            estaPreparandoKebab = false;
            asignarKebab();
            anyadirIngredienteKebab();
        }
    }
}
