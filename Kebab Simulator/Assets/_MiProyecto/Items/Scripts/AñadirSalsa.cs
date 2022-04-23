using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyadirSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //SPAWN DEL KEBAB
    [Header("Spawn Kebab")]
    public GameObject modeloKebab;
    private Transform puntoSpawn;

    [Header("Ingrediente")]
    public Salsa IngredienteData;

    [Header("Cantidad ingrediente")]
    public int cantidad = 10;

    private GameObject kebabEnPreparacion;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Start()
    {
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

    public void anyadirSalsa()
    {
        asignarKebab();

        if (kebabEnPreparacion.GetComponent<Kebab>().contieneSalsa() == false)
        {
            kebabEnPreparacion.GetComponent<Kebab>().salsa = IngredienteData;
            cantidad--;
            Debug.Log("Se ha añadido salsa al Kebab");
        }
        else
        {
            Debug.Log("El Kebab ya tiene salsa");
        }
    }
}
