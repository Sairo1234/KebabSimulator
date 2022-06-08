using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPartida : MonoBehaviour
{
    [Header("DataInfo")]
    public DataPlayerInfo infoJugador;

    [Header("Informacion")]
    public int nivel;
    public float reputacion;
    public float dinero;
    public int numDia;

    [Header("Tutoriales")]
    public bool TGNoHaSalido;
    public bool TCNoHaSalido;
    public bool TKNoHaSalido;
    public bool TTiendaNoHaSalido;
    public bool TAlmacenNoHaSalido;

    [Header("GameObjects")]
    public GameObject jugador;
    public GameObject GameManager;


    public void guardarPartida()
    {
        asignarInformacion();
        infoJugador.dinero = dinero;
        infoJugador.nivel = nivel;
        infoJugador.reputacion = reputacion;
        infoJugador.numDia = numDia;
        infoJugador.TCNoHaSalido = true;
        infoJugador.TGNoHaSalido = true;
        infoJugador.TKNoHaSalido = true;
        infoJugador.TTiendaNoHaSalido = true;
        infoJugador.TAlmacenNoHaSalido = true;
    }

    public void asignarInformacion()
    {
        nivel = jugador.GetComponent<ReputacionDinero>().Nivel;
        reputacion = jugador.GetComponent<ReputacionDinero>().Reputacion;
        dinero = jugador.GetComponent<ReputacionDinero>().Dinero;

        numDia = GameManager.GetComponent<GameManager>().numDia;

        /*TGNoHaSalido = GameManager.GetComponent<SetTutorial>().TGNoHaSalido;
        TCNoHaSalido = GameManager.GetComponent<SetTutorial>().TCNoHaSalido;
        TKNoHaSalido = GameManager.GetComponent<SetTutorial>().TKNoHaSalido;
        TTiendaNoHaSalido = GameManager.GetComponent<SetTutorial>().TTiendaNoHaSalido;
        TAlmacenNoHaSalido = GameManager.GetComponent<SetTutorial>().TAlmacenNoHaSalido;*/
    }
}