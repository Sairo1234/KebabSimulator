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



    void Start()
    {
        cliente = GetComponent<NavMeshAgent>();
        GameObject GameObjectsalida = GameObject.FindGameObjectWithTag("Salida");
        TransformSalida = GameObjectsalida.transform;
    }

    public void salir()
    {
        this.transform.parent.gameObject.transform.DetachChildren();
        this.gameObject.GetComponent<EntradaCliente>().enabled = false;
        cliente.SetDestination(TransformSalida.position);
        estaDesplazandose = true;
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
        if (cliente.remainingDistance == 0)
        {
            estaDesplazandose = false;
            Destroy(this.gameObject);
        }
    }

}
