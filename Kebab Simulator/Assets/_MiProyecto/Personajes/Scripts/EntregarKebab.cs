using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntregarKebab : MonoBehaviour
{
    //MOVIMIENTO A LA COCINA


    public Transform destinoCliente;
    public Transform destinoJugador;

    public GameObject cliente;
    public GameObject jugador;

    private bool estanDesplazandose = false;

    //ENTREGAR KEBAB
    private GameObject kebabParaEntregar;

    [Header("Animator Jugador")]
    public Animator animatorJugador;

    private void Start()
    {
        cliente = this.gameObject;
        jugador = GameObject.FindGameObjectWithTag("Player");

        destinoCliente = GameObject.FindGameObjectWithTag("EntregaC").transform;
        destinoJugador = GameObject.FindGameObjectWithTag("EntregaJ").transform;



    }
    private void Update()
    {
        if (estanDesplazandose)
        {
            comprobarDistacia();
        }

        if (animatorJugador == null)
        {
            animatorJugador = GameObject.FindGameObjectWithTag("ModeloJugador").GetComponent<Animator>();
        }


    }
    private void OnMouseDown()
    {
        if (this.enabled)
        {
            comprobarPedido();
        }


    }

    public void entregarKebab()
    {
        Destroy(kebabParaEntregar);
        animatorJugador.SetTrigger("DejaPlato");
        Debug.Log("Se ha tirado el kebab");

    }

    private void comprobarDistacia()
    {
        if (jugador.GetComponent<NavMeshAgent>().remainingDistance == 0 && cliente.GetComponent<NavMeshAgent>().remainingDistance == 0)
        {
            jugador.transform.LookAt(cliente.transform);
            cliente.transform.LookAt(jugador.transform);
            estanDesplazandose = false;
            entregarKebab();
            cliente.GetComponent<PacienciaEspera>().enabled = false;
            jugador.GetComponent<ReputacionDinero>().TakeReputacion(20);
            jugador.GetComponent<ReputacionDinero>().TakeDinero(5);
            cliente.GetComponent<SalidaCliente>().salir();
        }

    }

    private void asignarKebab()
    {

        kebabParaEntregar = GameObject.FindGameObjectWithTag("KebabEnPreparacion");


    }

    private void comprobarPedido()
    {
        Pedido pedidoCliente = cliente.GetComponent<Pedido>();
        asignarKebab();
        try
        {
            if (kebabParaEntregar.GetComponent<Kebab>().carne == pedidoCliente.carnePedido &&
                kebabParaEntregar.GetComponent<Kebab>().verdura == pedidoCliente.verduraPedido &&
                kebabParaEntregar.GetComponent<Kebab>().salsa == pedidoCliente.salsaPedido)
            {
                jugador.GetComponent<NavMeshAgent>().SetDestination(destinoJugador.position);
                cliente.GetComponent<NavMeshAgent>().SetDestination(destinoCliente.position);
                estanDesplazandose = true;


            }
        }
        catch
        {
            Debug.Log("Mal kebab");
        }

    }
}