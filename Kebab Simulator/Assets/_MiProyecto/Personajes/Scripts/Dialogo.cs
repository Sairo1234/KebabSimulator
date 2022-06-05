using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    //Cuadro de diálogo
    public GameObject PanelDialogo;

    //Animacion Jugador
    Animator animatorJugador;

    //Desplazamiento
    [Header("Desplazamiento")]
    public GameObject gameManager;

    public GameObject jugador;


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        animatorJugador = GameObject.FindGameObjectWithTag("ModeloJugador").GetComponent<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    public void mostrarDialogo()
    {
        this.gameObject.GetComponent<PacienciaCola>().enabled = false;
        this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayPidiendo();
        jugador.gameObject.GetComponent<SonidoJugadorController>().PlayTomandoNota();
        PanelDialogo.SetActive(true);
    }

    public void ocultarDialogo()
    {
        PanelDialogo.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().enabled = true;
        animatorJugador.SetTrigger("GuardarNota");
        gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
        this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
        this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
    }

}