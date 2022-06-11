using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AñadirSalsa : MonoBehaviour
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
    public int cantidad;

    [Header("Particulas salsa")]
    public GameObject particulasSalsa;

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
        particulasSalsa = transform.GetChild(2).gameObject;
    }

    public void asignarKebab()
    {
        if (puntoSpawn.childCount == 0 && IngredienteData.unidadesCocina > 0)
        {
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Animator>().SetTrigger("Interactuando");
            StartCoroutine(jugadorSinKebab());
            activarEfecto();
        }
        else if (puntoSpawn.childCount > 0 && IngredienteData.unidadesCocina > 0)
        {
            kebabEnPreparacion = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Animator>().SetTrigger("Interactuando");
            StartCoroutine(jugadorConKebab());
            activarEfecto();
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
        particulasSalsa.SetActive(false);

    }
    public void anyadirSalsa()
    {

        if (kebabEnPreparacion.GetComponent<Kebab>().contieneSalsa() == false)
        {
            kebabEnPreparacion.GetComponent<Kebab>().salsa = IngredienteData;
            IngredienteData.unidadesCocina--;
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
        yield return new WaitForSeconds(3);
        spawnKebabEnPlato();
        anyadirSalsa();
    }
    IEnumerator jugadorConKebab()
    {
        yield return new WaitForSeconds(3);
        anyadirSalsa();
    }

    public void activarEfecto()
    {
        if (particulasSalsa != null)
        {
            particulasSalsa.SetActive(true);
            Invoke("desactivarEfecto", 1);
        }

    }

    public void desactivarEfecto()
    {
        particulasSalsa.SetActive(false);
    }
}
