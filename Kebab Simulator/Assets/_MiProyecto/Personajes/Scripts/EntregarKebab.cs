using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntregarKebab : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //Desplazamiento
    public Transform destinoCliente;
    public Transform destinoJugador;
    public GameObject cliente;
    public GameObject jugador;
    //private bool estanDesplazandose = false;
    public bool estaDesplazandoseJugador = false;
    public bool estaDesplazandoseCliente = false;
    public bool estaJugadorUsandoObjeto = false;
    public bool estaJugadorHaciendoAccion = false;

    //Entregar kebab
    public GameObject kebabParaEntregar;

    //Animaciones
    [Header("Animator")]
    public Animator animatorJugador;
    public Animator animatorCliente;

    //GameManager
    private GameObject gameManager;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        cliente = this.gameObject;
        jugador = GameObject.FindGameObjectWithTag("Player");

        destinoCliente = GameObject.FindGameObjectWithTag("EntregaC").transform;
        destinoJugador = GameObject.FindGameObjectWithTag("EntregaJ").transform;

    }

    private void Update()
    {
        
        if (estaDesplazandoseJugador == true)
        {
            comprobarDistaciaJugador();
        }

        if (estaDesplazandoseCliente == true)
        {
            comprobarDistaciaCliente();
        }

        if (animatorJugador == null)
        {
            animatorJugador = GameObject.FindGameObjectWithTag("ModeloJugador").GetComponent<Animator>();
        }

    }

    private void OnMouseDown()
    {
        asignarKebab();
        if (this.enabled && kebabParaEntregar != null)
        {
            //Desactivar mostrar pedido
            this.gameObject.GetComponent<MostrarPedido>().enabled = false;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);

            //Desactivar paciencia espera
            cliente.GetComponent<PacienciaEspera>().enabled = false;

            desplazamientoEntregar();
        }
    }

    //-----------------------------------------------------------------------//
    //-------------------------- Entrega de kebab  --------------------------//

    private void comprobarPedido()
    {
        Pedido pedidoCliente = cliente.GetComponent<Pedido>();

        //Comprobar ingredredintes
        int contadorigredientesBien = 0;
        if (kebabParaEntregar.GetComponent<Kebab>().carne == pedidoCliente.carnePedido)
        {
            contadorigredientesBien++;
        }

        if (kebabParaEntregar.GetComponent<Kebab>().verdura == pedidoCliente.verduraPedido)
        {
            contadorigredientesBien++;
        }

        if (kebabParaEntregar.GetComponent<Kebab>().salsa == pedidoCliente.salsaPedido)
        {
            contadorigredientesBien++;
        }

        //Casos posibles de entrega
        switch (contadorigredientesBien)
        {
            case 0:
                entregarKebab();
                //Dinero y reputación obtenida
                jugador.GetComponent<ReputacionDinero>().TakeReputacion(5);
                jugador.GetComponent<ReputacionDinero>().TakeDinero(5);

                //Info de kebab perfecto
                gameManager.GetComponent<GameManager>().numKebabsIncorrectos++;
                break;
            case 1:
                entregarKebab();
                //Dinero y reputación obtenida
                jugador.GetComponent<ReputacionDinero>().TakeReputacion(25);
                jugador.GetComponent<ReputacionDinero>().TakeDinero(25);

                //Info de kebab perfecto
                gameManager.GetComponent<GameManager>().numKebabsIncorrectos++;
                break;
            case 2:
                entregarKebab();
                //Dinero y reputación obtenida
                jugador.GetComponent<ReputacionDinero>().TakeReputacion(50);
                jugador.GetComponent<ReputacionDinero>().TakeDinero(50);

                //Info de kebab perfecto
                gameManager.GetComponent<GameManager>().numKebabsIncorrectos++;
                break;
            case 3:
                entregarKebab();
                //Dinero y reputación obtenida
                jugador.GetComponent<ReputacionDinero>().TakeReputacion(100);
                jugador.GetComponent<ReputacionDinero>().TakeDinero(100);

                //Info de kebab perfecto
                gameManager.GetComponent<GameManager>().numKebabsPerfectos++;
                break;
        }

        contadorigredientesBien = 0;

    }

    public void entregarKebab()
    {
        Destroy(kebabParaEntregar);
        animatorJugador.SetTrigger("DejaPlato");
        animatorCliente.SetTrigger("Coger");
    }

    private void asignarKebab()
    {
        try
        {
            kebabParaEntregar = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
        }
        catch
        {
            //Poner animacion de que no puede entregar kebab
        }

    }

    //-----------------------------------------------------------------------//
    //-------------------------- Dezplazamiento  ----------------------------//

    public void desplazamientoEntregar()
    {
        jugador.GetComponent<NavMeshAgent>().SetDestination(destinoJugador.position);

        //Desplazamiento
        estaDesplazandoseJugador = true;
        estaJugadorUsandoObjeto = true;
        estaJugadorHaciendoAccion = true;

        //Desactivar desplazamiento de otros scripts
        gameManager.GetComponent<DesplazamientoController>().desactivarDesplazamientoPunto();
    }

    private void comprobarDistaciaJugador()
    {
        if (Vector3.Distance(jugador.transform.position, destinoJugador.position) < 1)
        {
            cliente.GetComponent<NavMeshAgent>().SetDestination(destinoCliente.position);
            estaDesplazandoseJugador = false;
            estaDesplazandoseCliente = true;

            //Sonido de campanita de llamar cliente
        }
    }

    private void comprobarDistaciaCliente()
    {
        
        if (Vector3.Distance(cliente.transform.position, destinoCliente.position) < 1)
        {
            //Mirar en la direccion correcta
            jugador.transform.LookAt(cliente.transform);
            cliente.transform.LookAt(jugador.transform);

            //Desplazamiento
            estaDesplazandoseCliente = false;
            estaJugadorUsandoObjeto = false;
            estaJugadorHaciendoAccion = false;

            //Accion que realiza
            comprobarPedido();

            //Salida del cliente
            StartCoroutine(SeVa());
        }
    }

    IEnumerator SeVa()
    {
        yield return new WaitForSeconds(2);

        //Activar desplazamiento de otros scripts
        gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
        this.gameObject.GetComponent<EntregarKebab>().enabled = false;

        cliente.GetComponent<SalidaCliente>().salir();
    }
}