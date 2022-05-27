using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazamientoController : MonoBehaviour
{
    [Header("Objetos con Desplazamiento Punto")]
    public List<GameObject> objetosDesplazamiento = new List<GameObject>();

    [Header("Cola 0")]
    public GameObject puntoColaCero;

    [Header("Jugador")]
    public GameObject jugador;

    void Update()
    {
        comprobarCliente();
    }

    public void comprobarCliente()
    {
        if(puntoColaCero.transform.GetChildCount() != 0 && objetosDesplazamiento.Count < 21)
        {
            objetosDesplazamiento.Add(puntoColaCero.transform.GetChild(0).gameObject);
        }
    }

    public void desactivarDesplazamientoPunto()
    {
        jugador.GetComponent<Player_Mov>().enabled = false;
        foreach (GameObject objeto in objetosDesplazamiento)
        {
            if (objeto.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto == false)
            {
                objeto.GetComponent<DesplazamientoPunto>().enabled = false;
            }
        }
    }

    public void activaDesplazamientoPunto()
    {
        jugador.GetComponent<Player_Mov>().enabled = true;
        foreach (GameObject objeto in objetosDesplazamiento)
        {
            if (objeto.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto == false)
            {
                objeto.GetComponent<DesplazamientoPunto>().enabled = true;
            }
        }
    }
}
