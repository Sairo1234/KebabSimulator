using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorClientesPuerta : MonoBehaviour
{
    public int contadorClientes;
    public int contadorClientesSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ClienteSaliendo")
        {
            contadorClientes++;
        }
        if (other.gameObject.tag == "Cliente")
        {
            contadorClientesSpawn++;
        }

    }

}
