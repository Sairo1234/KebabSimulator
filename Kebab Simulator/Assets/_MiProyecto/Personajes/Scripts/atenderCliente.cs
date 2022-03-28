using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class atenderCliente : MonoBehaviour
{
    //GAMEOBJECTS
    public NavMeshAgent jugador;
    public GameObject cliente;
    //public GameObject vista;

    //Llegar Destino
    public Transform destino;
    public bool estaAtendiendoCliente = false;
    public bool estaMirando = false;

    //Cinemachine
    public CinemachineVirtualCamera VirtualCameraBarra;
    private int counter = 0;

    private void Update()
    {
        //if(!agent.pathPending && agent.remainDistance == 0)
        if(estaAtendiendoCliente == true)
        {
            comprobarDistaciaBarra();
        }
        
    }

    private void OnMouseDown()
    {
        if(estaAtendiendoCliente == false && estaMirando == false )
        {
            jugador.SetDestination(destino.position);
            estaAtendiendoCliente = true;
        }
        /*else if(counter == 1 && estaMirando == false)
        {
            //cambioCamaraBarraMain();
            estaAtendiendoCliente = false;
            estaMirando = true;
        }*/
        else
        {
            cambioCamaraBarraMain();
            estaAtendiendoCliente = false;
            estaMirando = false;
        }
    }

    private void comprobarDistaciaBarra()
    {
        if (jugador.remainingDistance == 0 )
        {
            
            jugador.transform.LookAt(cliente.transform);
            estaAtendiendoCliente = false;
            estaMirando = true;
            cambioCamaraMainBarra();
        }
    }

    private void cambioCamaraMainBarra()
    {
        
            VirtualCameraBarra.Priority = 2;
            Camera.main.orthographic = false;
            counter++;
            Debug.Log("hola");
    }

    private void cambioCamaraBarraMain()
    {
        VirtualCameraBarra.Priority = 0;
        StartCoroutine(Ortografico());
        counter--;
        Debug.Log("adios");
        estaMirando = false;
    }

    IEnumerator Ortografico()
    {
        yield return new WaitForSeconds(2);
        Camera.main.orthographic = true;
    }

    /*private void cambioCamaraMainBarra()
    {
        if (counter == 0)
        {
            VirtualCameraBarra.Priority = 2;
            Camera.main.orthographic = false;

            counter++;
            Debug.Log("hola");
        }
        else
        {
            VirtualCameraBarra.Priority = 0;
            StartCoroutine(Ortografico());
            counter--;
            Debug.Log("adios");
        }
    }*/
}
