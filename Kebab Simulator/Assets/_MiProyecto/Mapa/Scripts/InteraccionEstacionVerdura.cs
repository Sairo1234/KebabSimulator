using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionEstacionVerdura : MonoBehaviour
{
    //SPAWN DEL KEBAB
    public GameObject modeloKebab;
    public Transform puntoSpawn;

    //GAMEOBJECT KEBAB
    public GameObject kebabEnPreparacion;

    void OnMouseDown()
    {
        asignarKebab();
        anyadirIngredienteKebab();
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
}
