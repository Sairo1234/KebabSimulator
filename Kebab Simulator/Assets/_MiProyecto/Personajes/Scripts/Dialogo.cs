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


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        animatorJugador = GameObject.FindGameObjectWithTag("ModeloJugador").GetComponent<Animator>();
    }

    public void mostrarDialogo()
    {
        this.gameObject.GetComponent<PacienciaCola>().enabled = false;
        PanelDialogo.SetActive(true);
    }

    public void ocultarDialogo()
    {
        PanelDialogo.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().enabled = true;
        animatorJugador.SetTrigger("GuardarNota");
        gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
    }

}
