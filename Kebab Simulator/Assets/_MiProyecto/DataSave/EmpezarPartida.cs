using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpezarPartida : MonoBehaviour
{
    [Header("DataInfo")]
    public DataPlayerInfo infoJugador;

    public void empezarPartida()
    {
        infoJugador.partidaEmpezada = true; ;
    }
}
