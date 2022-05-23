using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AñadirVerdura : MonoBehaviour
{
    ///----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //SPAWN DEL KEBAB
    [Header("Spawn Kebab")]
    public GameObject modeloKebab;
    private Transform puntoSpawn;

    [Header("Ingrediente")]
    public Verdura IngredienteData;

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
            StartCoroutine(jugadorSinKebab());
        }
        else
        {
            kebabEnPreparacion = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            Debug.Log("Ya hay un kebab");
            anyadirVerdura();
        }
    }

    public void spawnKebabEnPlato()
    {
        GameObject NuevoKebabEnPreparacion = Instantiate(modeloKebab, puntoSpawn);
        NuevoKebabEnPreparacion.tag = "KebabEnPreparacion";
        kebabEnPreparacion = NuevoKebabEnPreparacion;
        Debug.Log("Kebab spawneado");
    }

    public void anyadirVerdura()
    {

        if (kebabEnPreparacion.GetComponent<Kebab>().contieneVerdura() == false)
        {
            kebabEnPreparacion.GetComponent<Kebab>().verdura = IngredienteData;
            cantidad--;
            Debug.Log("Se ha añadido verdura al Kebab");
        }
        else
        {
            Debug.Log("El Kebab ya tiene verdura");
        }
    }

    IEnumerator jugadorSinKebab()
    {
        yield return new WaitForSeconds(4);
        spawnKebabEnPlato();
        anyadirVerdura();
    }
}
