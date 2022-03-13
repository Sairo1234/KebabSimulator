using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MaquinaFSM : MonoBehaviour
{
    EntradaCliente entrada;
    SalidaCliente salida;
    // Start is called before the first frame update
    void Start()
    {
        entrada = GetComponent<EntradaCliente>();
        salida = GetComponent<SalidaCliente>();

        entrada.enabled = true;
        salida.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetEstado(salida);
        }
    }

    public void SetEstado(MonoBehaviour estado)
    {
        if(estado == entrada)
        {
            entrada.enabled = true;
            salida.enabled = false;
        }
        else
        {
            entrada.enabled = false;
            salida.enabled = true;
        }
    }
}
