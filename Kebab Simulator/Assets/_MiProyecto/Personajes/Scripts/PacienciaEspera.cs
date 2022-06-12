using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacienciaEspera : MonoBehaviour
{
    public float timeRemaining = 80;

    [Header("Animator Cliente")]
    public Animator animatorCliente;
    private bool aunNoSeHaQuejado = true;

    [Header("GameManager")]
    private GameObject gameManager;

    [Header("Audio")]
    public GameObject jugador;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (aunNoSeHaQuejado && timeRemaining <= 20)
        {
            animatorCliente.SetTrigger("Impaciente");
            this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayImpaciente();
            timeRemaining -= Time.deltaTime;
            aunNoSeHaQuejado = false;

        }
        else if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            this.gameObject.GetComponent<SalidaCliente>().rechazoPedido();
            this.gameObject.GetComponent<SalidaCliente>().salir();
            gameManager.GetComponent<GameManager>().clientesPerdidos++;

            this.GetComponent<MostrarEmociones>().MostrarKebabMalo();
            this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayFrustrado();
            StartCoroutine("JugadorTriste");

            this.enabled = false;
        }
    }

    //Make an ienumerable to PLayTriste a second later
    IEnumerator JugadorTriste()
    {
        yield return new WaitForSeconds(1);
        jugador.GetComponent<SonidoJugadorController>().PlayTriste();
    }
}