using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.UI;


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

    //Cuadro de diálogo
    public GameObject dialogoClienteCanvas;

    public bool acabado = false;

    private void Start()
    {
        GameObject GameObjectdestino = GameObject.FindGameObjectWithTag("PosicionAtender");
        destino = GameObjectdestino.transform;

        VirtualCameraBarra = GameObject.FindGameObjectWithTag("CamaraBarra").GetComponent<CinemachineVirtualCamera>();
        dialogoClienteCanvas = GameObject.FindGameObjectWithTag("cuadro");
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
       

    }

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
        if(estaAtendiendoCliente == false && estaMirando == false && this.enabled)
        {
            estaAtendiendoCliente = true;
            jugador.SetDestination(destino.position);
            StartCoroutine(Dialogo());
            
        }
        else
        {
            cambioCamaraBarraMain();
            estaAtendiendoCliente = false;
            estaMirando = false;
            dialogoClienteCanvas.transform.GetChild(0).gameObject.SetActive(false);
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
        acabado = true;
    }

    IEnumerator Ortografico()
    {
        yield return new WaitForSeconds(1);
        Camera.main.orthographic = true;
    }

    IEnumerator Dialogo()
    {
        yield return new WaitForSeconds(2);
        dialogoClienteCanvas.transform.GetChild(0).gameObject.SetActive(true);
    }

    
}
