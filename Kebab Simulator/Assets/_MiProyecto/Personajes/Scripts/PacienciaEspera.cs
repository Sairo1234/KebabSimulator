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

            jugador.GetComponent<SonidoJugadorController>().PlayTriste();

            this.enabled = false;
        }
    }
}
