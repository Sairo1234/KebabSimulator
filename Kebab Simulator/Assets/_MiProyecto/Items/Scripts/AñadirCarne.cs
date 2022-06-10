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
        cantidad = IngredienteData.unidadesCocina;
        puntoSpawn = GameObject.FindGameObjectWithTag("SpawnKebab").transform;
    }

    public void asignarKebab()
    {

        if (puntoSpawn.childCount == 0 && IngredienteData.unidadesCocina > 0)
        {
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Animator>().SetTrigger("Interactuando");
            StartCoroutine(jugadorSinKebab());
        }
        else if (puntoSpawn.childCount > 0 && IngredienteData.unidadesCocina > 0)
        {
            kebabEnPreparacion = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Animator>().SetTrigger("Interactuando");
            StartCoroutine(jugadorConKebab());
        }
        else
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            jugador.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Nop");
            jugador.transform.eulerAngles = new Vector3(0, 60, 0);

            jugador.GetComponent<SonidoJugadorController>().PlayFrustrado();

            this.GetComponent<AudioSource>().Stop();
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
            IngredienteData.unidadesCocina--;
            gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
            particulasCarne.SetActive(true);
            Invoke("desactivarefecto", 2);
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
        yield return new WaitForSeconds(3);
        spawnKebabEnPlato();
        anyadirCarne();
    }

    IEnumerator jugadorConKebab()
    {
        yield return new WaitForSeconds(3);
        anyadirCarne();
    }

}
