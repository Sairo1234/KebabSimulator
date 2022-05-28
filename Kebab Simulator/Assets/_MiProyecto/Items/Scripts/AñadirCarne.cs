using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AñadirCarne : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //Sapwn Kebab
    [Header("Spawn Kebab")]
    public GameObject modeloKebab;
    private Transform puntoSpawn;

    //Ingrediente
    [Header("Ingrediente")]
    public Carne IngredienteData;

    //Cantidad
    [Header("Cantidad ingrediente")]
    public int cantidad;

    [Header("Particulas carne")]
    public GameObject particulasCarne;

    //Desplazamiento
    [Header("Desplazamiento")]
    public GameObject gameManager;

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
            StartCoroutine(jugadorConKebab());
        }
    }

    public void spawnKebabEnPlato()
    {
        kebabEnPreparacion = Instantiate(modeloKebab, puntoSpawn);
        kebabEnPreparacion.tag = "KebabEnPreparacion";
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
            gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
        }
        else
        {
            gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
        }
    }

    IEnumerator jugadorSinKebab()
    {
        yield return new WaitForSeconds(4);
        spawnKebabEnPlato();
        anyadirCarne();
    }

    IEnumerator jugadorConKebab()
    {
        yield return new WaitForSeconds(4);
        anyadirCarne();
    }

}
