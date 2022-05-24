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
    [Header("Particulas carne")]
    public GameObject particulasCarne;

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
            StartCoroutine(jugadorSinKebab());
        }
        else if(puntoSpawn.childCount > 0)
        {
            kebabEnPreparacion = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            Debug.Log("Ya hay un kebab");
            anyadirCarne();
        }
    }

    public void spawnKebabEnPlato()
    {
        kebabEnPreparacion = Instantiate(modeloKebab, puntoSpawn);
        kebabEnPreparacion.tag = "KebabEnPreparacion";
        Debug.Log("Kebab spawneado");
    }
    public void desactivarefecto()
    {
        particulasCarne.SetActive(false);

    }
    public void anyadirCarne()
    {
        if (kebabEnPreparacion.GetComponent<Kebab>().contieneCarne() == false)
        {
            kebabEnPreparacion.GetComponent<Kebab>().carne = IngredienteData;
            cantidad--;
            particulasCarne.SetActive(true);
            Invoke("desactivarefecto", 2);
            Debug.Log("Se ha añadido carne al Kebab");
        }
        else
        {
            Debug.Log("El Kebab ya tiene carne");
        }
    }

    IEnumerator jugadorSinKebab()
    {
        yield return new WaitForSeconds(4);
        spawnKebabEnPlato();
        anyadirCarne();
    }

}
