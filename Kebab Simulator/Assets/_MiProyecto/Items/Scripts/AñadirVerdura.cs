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
    public int cantidad;

    //Desplazamiento
    [Header("Desplazamiento")]
    public GameObject gameManager;

    private GameObject kebabEnPreparacion;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Start()
    {
        if (IngredienteData.unidadesAlmacen > 0)
        {
            cantidad = 5;
        }
        puntoSpawn = GameObject.FindGameObjectWithTag("SpawnKebab").transform;
    }

    public void asignarKebab()
    {
        if (puntoSpawn.childCount == 0 && cantidad > 0)
        {
            StartCoroutine(jugadorSinKebab());
        }
        else if(puntoSpawn.childCount > 0 && cantidad > 0)
        {
            kebabEnPreparacion = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            StartCoroutine(jugadorConKebab());
        }
         else
        {
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Animator>().SetTrigger("DejaPlatoMesa");
            gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
        }
    }

    public void spawnKebabEnPlato()
    {
        GameObject NuevoKebabEnPreparacion = Instantiate(modeloKebab, puntoSpawn);
        NuevoKebabEnPreparacion.tag = "KebabEnPreparacion";
        kebabEnPreparacion = NuevoKebabEnPreparacion;
    }

    public void anyadirVerdura()
    {

        if (kebabEnPreparacion.GetComponent<Kebab>().contieneVerdura() == false)
        {
            kebabEnPreparacion.GetComponent<Kebab>().verdura = IngredienteData;
            cantidad--;
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
        anyadirVerdura();
    }

    IEnumerator jugadorConKebab()
    {
        yield return new WaitForSeconds(4);
        anyadirVerdura();
    }
}
