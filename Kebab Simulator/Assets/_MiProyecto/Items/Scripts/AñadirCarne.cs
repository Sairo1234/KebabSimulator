using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AñadirCarne : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //SPAWN DEL KEBAB
    [Header("Spawn Kebab")]
    public GameObject modeloKebab;
    private Transform puntoSpawn;

    [Header("Ingrediente")]
    public Carne IngredienteData;

    [Header("Cantidad ingrediente")]
    public int cantidad;

    private GameObject kebabEnPreparacion;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Start()
    {
        cantidad = IngredienteData.capacidadMaxIngrediente;
        puntoSpawn = GameObject.FindGameObjectWithTag("SpawnKebab").transform;
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

    public void anyadirCarne()
    {
        asignarKebab();

        if (kebabEnPreparacion.GetComponent<Kebab>().contieneCarne() == false)
        {
            kebabEnPreparacion.GetComponent<Kebab>().carne = IngredienteData;
            cantidad--;
            Debug.Log("Se ha añadido carne al Kebab");
        }
        else
        {
            Debug.Log("El Kebab ya tiene carne");
        }
    }
   
}
