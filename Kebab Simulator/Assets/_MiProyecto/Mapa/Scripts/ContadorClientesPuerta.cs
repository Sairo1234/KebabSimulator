using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorClientesPuerta : MonoBehaviour
{
    public int contadorClientes;
    public int contadorClientesSpawn;
    public AudioSource audioSourceEntrada;
    public AudioSource audioSourceSalida;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ClienteSaliendo")
        {
            contadorClientes++;
            audioSourceSalida.Play();
        }
        if (other.gameObject.tag == "Cliente")
        {
            contadorClientesSpawn++;
            audioSourceEntrada.Play();
        }

    }

}
