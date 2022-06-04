using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CogerKebab : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //Posicion SpawnKebab
    private Transform puntoSpawnKebab;

    //Kebab que se va a coger
    private GameObject kebabParaCoger;

    //MOVIMIENTO A LA MESA
    public Transform destinoMesa;
    private NavMeshAgent jugador;
    private GameObject kebab;
    private bool estaDesplazandose = false;
    public bool estaJugadorUsandoObjeto = false;
    public bool estaJugadorHaciendoAccion = false;

    //Animacion CogerKebab
    public Animator animatorJugador;

    [Header("Audio")]
    public AudioSource audioSource;

    //GameManager
    private GameObject gameManager;


    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Start()
    {
        kebab = this.gameObject;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        destinoMesa = GameObject.FindGameObjectWithTag("MesaPunto").transform;
        animatorJugador = GameObject.FindGameObjectWithTag("ModeloJugador").GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        puntoSpawnKebab = GameObject.FindGameObjectWithTag("SpawnKebab").transform;
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (this.enabled && puntoSpawnKebab.childCount == 0)
        {
            jugador.GetComponent<Player_Mov>().enabled = false;
            jugador.SetDestination(destinoMesa.position);
            estaDesplazandose = true;
            estaJugadorUsandoObjeto = true;
            estaJugadorHaciendoAccion = true;
            gameManager.GetComponent<DesplazamientoController>().desactivarDesplazamientoPunto();
        }
    }


    //--------------------------------------------------------------------------//
    //----------------------------- DESPLAZAR A MESA ---------------------------//

    private void Update()
    {
        if (estaDesplazandose == true)
        {
            comprobarDistaciaMesa();
        }
        audioSource.enabled = true;
    }

    private void comprobarDistaciaMesa()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(kebab.transform);
            estaDesplazandose = false;
            estaJugadorUsandoObjeto = false;
            estaJugadorHaciendoAccion = false;
            colocarKebabEnJugador();

        }
    }

    //--------------------------------------------------------------------------//
    //----------------------- COLOCAR KEBAB EN JUGADOR -------------------------//

    public void colocarKebabEnJugador()
    {
        kebabParaCoger = this.gameObject;
        animatorJugador.SetTrigger("CogePlatoMesa");
        StartCoroutine(spawnKebabMesa());


    }

    IEnumerator spawnKebabMesa()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject KebabEnJugador = Instantiate(kebabParaCoger, puntoSpawnKebab);
        Destroy(this.gameObject);
        KebabEnJugador.tag = "KebabEnPreparacion";
        KebabEnJugador.GetComponent<OutlineDeObjeto>().enabled = true;
        KebabEnJugador.GetComponent<CogerKebab>().enabled = false;
        KebabEnJugador.GetComponent<MostrarIngredientesKebab>().enabled = true;
        gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
        if (audioSource != null)
        {
            audioSource.Play();
        }

    }

}