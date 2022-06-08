using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetearPartida : MonoBehaviour
{
    [Header("DataInfo")]
    public DataPlayerInfo infoJugador;

    public void resetPartida()
    {
        //InfoJugador
        infoJugador.dinero = 0;
        infoJugador.nivel = 1;
        infoJugador.reputacion = 25;
        infoJugador.numDia = 1;

        //Tutoriales
        /*infoJugador.TCNoHaSalido = true;
        infoJugador.TGNoHaSalido = true;
        infoJugador.TKNoHaSalido = true;
        infoJugador.TTiendaNoHaSalido = true;
        infoJugador.TAlmacenNoHaSalido = true;*/
    }
}
