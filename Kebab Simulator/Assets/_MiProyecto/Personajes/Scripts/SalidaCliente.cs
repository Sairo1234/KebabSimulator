using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SalidaCliente : MonoBehaviour
{

    [Header("Transforms salida")]
    public Transform TransformSalida;
    private bool estaDesplazandose = false;

    NavMeshAgent cliente;
    private GameObject jugador;

    public Animator animatorCliente;

    //Desplazamiento
    [Header("Desplazamiento")]
    public GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        cliente = GetComponent<NavMeshAgent>();
        GameObject GameObjectsalida = GameObject.FindGameObjectWithTag("Salida");
        TransformSalida = GameObjectsalida.transform;

        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    public void salir()
    {
        this.gameObject.tag = "ClienteSaliendo";
        animatorCliente.SetBool("Andando", true);
        this.transform.parent.gameObject.transform.DetachChildren();
        this.gameObject.GetComponent<EntradaCliente>().enabled = false;
        this.gameObject.GetComponent<EntregarKebab>().enabled = false;
        cliente.SetDestination(TransformSalida.position);
        estaDesplazandose = true;
        //this.gameObject.transform.GetChild(2).GetComponent<OutlineDeObjeto>().enabled = false;

        //EliminarCliente de desplazamientoController
        gameManager.GetComponent<DesplazamientoController>().objetosDesplazamiento.Remove(this.gameObject);


    }

    public void rechazoPedido()
    {
        jugador.GetComponent<ReputacionDinero>().TakeReputacion(-10);
    }


    private void Update()
    {
        if (estaDesplazandose == true)
        {
            comprobarDistacia();
        }
    }

    private void comprobarDistacia()
    {
        if (Vector3.Distance(this.gameObject.transform.position , TransformSalida.position) < 0.5)
        {
            estaDesplazandose = false;
            Destroy(this.gameObject);
        }
    }

}
