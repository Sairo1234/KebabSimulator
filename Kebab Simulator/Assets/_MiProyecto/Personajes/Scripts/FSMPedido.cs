using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSMPedido : MonoBehaviour
{
    atenderCliente Atender;
    EntregarKebab Entregar;
    EntradaCliente entrada;
    SalidaCliente salida;

    // Start is called before the first frame update
    void Start()
    {
        Atender = GetComponent<atenderCliente>();
        Entregar = GetComponent<EntregarKebab>();
        entrada = GetComponent<EntradaCliente>();
        salida = GetComponent<SalidaCliente>();

        Atender.enabled = true;
        Entregar.enabled = false;
        entrada.enabled = true;
        salida.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Atender.acabado==true)
        {
            SetEstado(Entregar);
        }
       
    }

    public void SetEstado(MonoBehaviour estado)
    {
        if (estado == Atender)
        {
            Atender.enabled = true;
            Entregar.enabled = false;
            entrada.enabled = true;
            salida.enabled = false;
        }
        else
        {
            Atender.enabled = false;
            Entregar.enabled = true;
            entrada.enabled = false;
           // salida.enabled = true;
        }
    }
}
