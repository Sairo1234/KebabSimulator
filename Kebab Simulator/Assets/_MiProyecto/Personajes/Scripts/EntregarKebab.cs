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
    private bool estanDesplazandose = false;
    public bool estaJugadorUsandoObjeto = false;
    public bool estaJugadorHaciendoAccion = false;

    //Entregar kebab
    private GameObject kebabParaEntregar;

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
            this.gameObject.GetComponent<MostrarPedido>().enabled=false;
            comprobarPedido();
        }
    }

    //-----------------------------------------------------------------------//
    //-------------------------- Entrega de kebab  --------------------------//

    public void entregarKebab()
    {
        Destroy(kebabParaEntregar);
        animatorJugador.SetTrigger("DejaPlato");
        animatorCliente.SetTrigger("Coger");
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

                //Desplazamiento
                estanDesplazandose = true;
                estaJugadorUsandoObjeto = true;
                estaJugadorHaciendoAccion = true;

                //Desactivar desplazamiento de otros scripts
                gameManager.GetComponent<DesplazamientoController>().desactivarDesplazamientoPunto();
            }
        }
        catch
        {
            Debug.Log("El kebab esta incorrecto");
        }

    }

    //-----------------------------------------------------------------------//
    //-------------------------- Dezplazamiento  ----------------------------//

    private void comprobarDistacia()
    {
        if (jugador.GetComponent<NavMeshAgent>().remainingDistance == 0 && cliente.GetComponent<NavMeshAgent>().remainingDistance == 0)
        {
            //Mirar en la direccion correcta
            jugador.transform.LookAt(cliente.transform);
            cliente.transform.LookAt(jugador.transform);

            //Desplazamiento
            estanDesplazandose = false;
            estaJugadorUsandoObjeto = false;
            estaJugadorHaciendoAccion = false;

            //Accion que realiza
            entregarKebab();

            //Dinero y reputación obtenida
            jugador.GetComponent<ReputacionDinero>().TakeReputacion(100);
            jugador.GetComponent<ReputacionDinero>().TakeDinero(100);
            cliente.GetComponent<PacienciaEspera>().enabled = false;
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