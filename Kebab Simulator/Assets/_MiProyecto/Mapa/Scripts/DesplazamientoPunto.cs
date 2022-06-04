using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DesplazamientoPunto : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//


    private NavMeshAgent jugador;
    private GameObject gameObjectAsignado;
    private Transform destino;
    private bool estaDesplazandose = false;
    public bool estaJugadorUsandoObjeto = false;
    public bool estaJugadorHaciendoAccion = false;

    [Header("Animator Jugador")]
    public Animator animatorJugador;
    public string animacionJugador;

    [Header("Tag")]
    public string tagGameObject;

    [Header("Funcion a realizar")]
    public string funcionScript;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] audioClip;

    [Header("GameManager")]
    public GameObject gameManager;


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        gameObjectAsignado = this.gameObject;
        GameObject GameObjectdestino = GameObject.FindGameObjectWithTag(tagGameObject);
        destino = GameObjectdestino.transform;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (estaDesplazandose == true)
        {
            comprobarDistacia();
        }

        if (animatorJugador == null)
        {
            animatorJugador = GameObject.FindGameObjectWithTag("ModeloJugador").GetComponent<Animator>();
        }

    }

    void OnMouseDown()
    {
        if (this.enabled && estaJugadorHaciendoAccion == false)
        {
            jugador.SetDestination(destino.position);
            estaDesplazandose = true;
            estaJugadorUsandoObjeto = true;
            estaJugadorHaciendoAccion = true;
            gameManager.GetComponent<DesplazamientoController>().desactivarDesplazamientoPunto();
            animatorJugador.SetBool("Andando", true);
        }
    }

    private void comprobarDistacia()
    {
        if (jugador.remainingDistance == 0 && estaDesplazandose == true)
        {
            jugador.transform.LookAt(gameObjectAsignado.transform);
            estaDesplazandose = false;
            animatorJugador.SetBool("Andando", false);
            animatorJugador.SetTrigger(animacionJugador);

            if (audioSource != null)
            {
                int audioRandom = Random.Range(0, audioClip.Length);
                audioSource.clip = audioClip[audioRandom];
                audioSource.Play();
            }

            if (estaJugadorHaciendoAccion == true)
            {
                gameObjectAsignado.SendMessage(funcionScript, null);
            }
            /* else
             {
                 gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
                 this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
             }*/
        }
    }
}


