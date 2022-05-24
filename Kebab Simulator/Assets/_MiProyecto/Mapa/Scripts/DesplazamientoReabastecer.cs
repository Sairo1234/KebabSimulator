using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DesplazamientoReabastecer : MonoBehaviour
{
    [Header("Desplazamiento")]
    public Transform puntoPosicion;
    public GameObject jugador;
    public GameObject estacion;
    public bool estaDesplazandose = false;


    [Header("Animator Juagdor")]
    public Animator animatorJugador;

    private void Update()
    {
        if (estaDesplazandose == true)
        {
            comprobarDistacia();
        }
    }


    public void desplazarEstacion()
    {
        jugador.GetComponent<NavMeshAgent>().SetDestination(puntoPosicion.position);
        animatorJugador.SetBool("Andando", true);
        jugador.GetComponent<Player_Mov>().enabled = false;
        estaDesplazandose = true;
    }

    private void comprobarDistacia()
    {
        if (jugador.GetComponent<NavMeshAgent>().remainingDistance == 0)
        {
            jugador.transform.LookAt(estacion.transform);
            estaDesplazandose = false;
            animatorJugador.SetBool("Andando", false);
            animatorJugador.SetTrigger("Interactuando");
            jugador.GetComponent<Player_Mov>().enabled = true;

        }
    }
}
