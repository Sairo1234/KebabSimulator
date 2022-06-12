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

        jugador.GetComponent<SonidoJugadorController>().PlayContento();
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

        //Precio del kebab
        float precioKebabEntregar = 0;

        //Comprobar ingredredintes
        int contadorigredientesBien = 0;
        if (kebabParaEntregar.GetComponent<Kebab>().carne == pedidoCliente.carnePedido)
        {
            contadorigredientesBien++;
            precioKebabEntregar += kebabParaEntregar.GetComponent<Kebab>().carne.precioVenta;
        }

        if (kebabParaEntregar.GetComponent<Kebab>().verdura == pedidoCliente.verduraPedido)
        {
            contadorigredientesBien++;
            precioKebabEntregar += kebabParaEntregar.GetComponent<Kebab>().verdura.precioVenta;
        }

        if (kebabParaEntregar.GetComponent<Kebab>().salsa == pedidoCliente.salsaPedido)
        {
            contadorigredientesBien++;
            precioKebabEntregar += kebabParaEntregar.GetComponent<Kebab>().salsa.precioVenta;
        }

        //Casos posibles de entrega
        switch (contadorigredientesBien)
        {
            case 0:
                entregarKebab();
                //Dinero y reputación obtenida
                jugador.GetComponent<ReputacionDinero>().TakeReputacion(-25);
                jugador.GetComponent<ReputacionDinero>().TakeDinero(precioKebabEntregar);

                //Info de kebab perfecto
                gameManager.GetComponent<GameManager>().numKebabsIncorrectos++;

                //Sonido Jugador Triste y Cliente Frustado
                this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayFrustrado();
                this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayDinero();

                this.GetComponent<MostrarEmociones>().MostrarKebabMalo();
                StartCoroutine("JugadorTriste");
                break;

            case 1:
                entregarKebab();
                //Dinero y reputación obtenida
                jugador.GetComponent<ReputacionDinero>().TakeReputacion(0);
                jugador.GetComponent<ReputacionDinero>().TakeDinero(precioKebabEntregar);

                //Info de kebab perfecto
                gameManager.GetComponent<GameManager>().numKebabsIncorrectos++;

                //Sonido Jugador Tristey y Cliente Frustado
                this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayFrustrado();
                this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayDinero();

                this.GetComponent<MostrarEmociones>().MostrarKebabMalo();
                StartCoroutine("JugadorTriste");
                break;

            case 2:
                entregarKebab();
                //Dinero y reputación obtenida
                jugador.GetComponent<ReputacionDinero>().TakeReputacion(10);
                jugador.GetComponent<ReputacionDinero>().TakeDinero(precioKebabEntregar);

                //Info de kebab perfecto
                gameManager.GetComponent<GameManager>().numKebabsIncorrectos++;

                //Sonido Jugador Tristey y Cliente Frustado
                this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayFrustrado();
                this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayDinero();

                this.GetComponent<MostrarEmociones>().MostrarKebabMalo();
                StartCoroutine("JugadorTriste");
                break;

            case 3:
                entregarKebab();
                //Dinero y reputación obtenida
                jugador.GetComponent<ReputacionDinero>().TakeReputacion(25);
                jugador.GetComponent<ReputacionDinero>().TakeDinero(precioKebabEntregar);

                //Info de kebab perfecto
                gameManager.GetComponent<GameManager>().numKebabsPerfectos++;

                //Sonido Jugador Contento y Cliente Contento
                this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayContento();
                this.gameObject.GetComponentInChildren<SonidoClienteController>().PlayDinero();

                this.GetComponent<MostrarEmociones>().MostrarKebabPerfecto();
                StartCoroutine("JugadorContento");
                break;
        }

        //Info de dinero ganado
        gameManager.GetComponent<GameManager>().dineroGanado += precioKebabEntregar;

        precioKebabEntregar = 0;
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
            jugador.GetComponent<SonidoJugadorController>().PLayCampanita();
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

    IEnumerator JugadorTriste()
    {
        yield return new WaitForSeconds(1);
        jugador.GetComponent<SonidoJugadorController>().PlayTriste();
    }

    IEnumerator JugadorContento()
    {
        yield return new WaitForSeconds(1);
        jugador.GetComponent<SonidoJugadorController>().PlayContento();
    }
}