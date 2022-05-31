using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazamientoController : MonoBehaviour
{
    [Header("Objetos con Desplazamiento")]
    public List<GameObject> objetosDesplazamiento = new List<GameObject>();
    public GameObject[] kebabsMesa;
    public GameObject[] clientesEsperando;

    [Header("Cola 0")]
    public GameObject puntoColaCero;

    [Header("Jugador")]
    public GameObject jugador;

    void Update()
    {
        comprobarCliente();
        comprobarKebabsMesa();
        comprobarClientesEspera();
    }

    public void comprobarCliente()
    {
        if(puntoColaCero.transform.GetChildCount() != 0 && objetosDesplazamiento.Count < 21)
        {
            objetosDesplazamiento.Add(puntoColaCero.transform.GetChild(0).gameObject);
        }
    }

    public void comprobarClientesEspera()
    {
        clientesEsperando = GameObject.FindGameObjectsWithTag("ClienteEsperando");
    }

    public void comprobarKebabsMesa()
    {
        kebabsMesa = GameObject.FindGameObjectsWithTag("KebabEnMesa");
    }

    public void desactivarDesplazamientoPunto()
    {
        jugador.GetComponent<Player_Mov>().enabled = false;
        puntoColaCero.GetComponent<AtenderController>().enabled = false;

        objetosDesplazamiento[0].GetComponent<BasuraController>().enabled = false;
        objetosDesplazamiento[1].GetComponent<MesaController>().enabled = false;
        objetosDesplazamiento[2].GetComponent<AlmacenControllers>().enabled = false;

        foreach (GameObject objeto in objetosDesplazamiento)
        {
            if (objeto.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto == false)
            {
                objeto.GetComponent<DesplazamientoPunto>().enabled = false;
            }
        }
        foreach (GameObject kebabEnMesa in kebabsMesa)
        {
            if (kebabEnMesa.GetComponent<CogerKebab>().estaJugadorUsandoObjeto == false)
            {
                kebabEnMesa.GetComponent<CogerKebab>().enabled = false;
            }
        }
        foreach (GameObject clienteEsperando in clientesEsperando)
        {
            if (clienteEsperando.GetComponent<EntregarKebab>().estaJugadorUsandoObjeto == false)
            {
                clienteEsperando.GetComponent<EntregarKebab>().enabled = false;
            }
        }
    }

    public void activaDesplazamientoPunto()
    {
        jugador.GetComponent<Player_Mov>().enabled = true;
        puntoColaCero.GetComponent<AtenderController>().enabled = true;

        objetosDesplazamiento[0].GetComponent<BasuraController>().enabled = true;
        objetosDesplazamiento[1].GetComponent<MesaController>().enabled = true;
        objetosDesplazamiento[2].GetComponent<AlmacenControllers>().enabled = true;

        foreach (GameObject objeto in objetosDesplazamiento)
        {
            if (objeto.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto == false)
            {
                objeto.GetComponent<DesplazamientoPunto>().enabled = true;
            }
        }
        foreach (GameObject kebabEnMesa in kebabsMesa)
        {
            if (kebabEnMesa.GetComponent<CogerKebab>().estaJugadorUsandoObjeto == false)
            {
                kebabEnMesa.GetComponent<CogerKebab>().enabled = true;
            }
        }
        foreach (GameObject clienteEsperando in clientesEsperando)
        {
            if (clienteEsperando.GetComponent<EntregarKebab>().estaJugadorUsandoObjeto == false)
            {
                clienteEsperando.GetComponent<EntregarKebab>().enabled = true;
            }
        }
    }
}
