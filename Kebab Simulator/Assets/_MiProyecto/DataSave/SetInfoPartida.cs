using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInfoPartida : MonoBehaviour
{
    [Header("DataInfo")]
    public DataPlayerInfo infoJugador;

    [Header("GameObjects")]
    public GameObject jugador;
    public GameObject GameManager;

    private void Start()
    {
        setInformacionPartida();
    }


    public void setInformacionPartida()
    {
        jugador.GetComponent<ReputacionDinero>().Nivel = infoJugador.nivel;
        jugador.GetComponent<ReputacionDinero>().Reputacion = infoJugador.reputacion;
        jugador.GetComponent<ReputacionDinero>().Dinero = infoJugador.dinero;
        GameManager.GetComponent<GameManager>().numDia = infoJugador.numDia;
       /* GameManager.GetComponent<SetTutorial>().TGNoHaSalido = infoJugador.TGNoHaSalido;
        GameManager.GetComponent<SetTutorial>().TCNoHaSalido = infoJugador.TCNoHaSalido;
        GameManager.GetComponent<SetTutorial>().TKNoHaSalido = infoJugador.TKNoHaSalido;
        GameManager.GetComponent<SetTutorial>().TTiendaNoHaSalido = infoJugador.TTiendaNoHaSalido;
        GameManager.GetComponent<SetTutorial>().TAlmacenNoHaSalido = infoJugador.TAlmacenNoHaSalido;*/
    }
}
