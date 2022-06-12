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
    Animator animatorCliente;

    //Desplazamiento
    [Header("Desplazamiento")]
    public GameObject gameManager;

    public GameObject jugador;


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        animatorJugador = GameObject.FindGameObjectWithTag("ModeloJugador").GetComponent<Animator>();
        animatorCliente = this.transform.GetComponentInChildren<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    public void mostrarDialogo()
    {
        animatorCliente.SetTrigger("Pedir");
        gameManager.GetComponent<SetTutorial>().PonerTutorialCliente();
        this.gameObject.GetComponent<PacienciaCola>().enabled = false;
        this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayPidiendo();
        jugador.gameObject.GetComponent<SonidoJugadorController>().PlayTomandoNota();
        StartCoroutine("ponerPanelDialogo");
    }

    public void ocultarDialogo()
    {
        PanelDialogo.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().enabled = true;
        animatorCliente.SetTrigger("PararPedir");        
        animatorJugador.SetTrigger("GuardarNota");
        gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
        this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
        this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
    }
    //set panel dialogo active a second later
    IEnumerator ponerPanelDialogo()
    {
        yield return new WaitForSeconds(0.01f);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<DesplazamientoController>().desactivarDesplazamientoPunto();

        PanelDialogo.SetActive(true);
    }

    
}