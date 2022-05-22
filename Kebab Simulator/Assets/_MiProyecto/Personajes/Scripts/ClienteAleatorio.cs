using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteAleatorio : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Modelos Clientes")]
    public  GameObject[] ModelosClientes;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Start()
    {
        seleccionarModeloAleatorio();
    }

    public void seleccionarModeloAleatorio()
    {
        GameObject cliente = Instantiate(ModelosClientes[Random.RandomRange(0, ModelosClientes.Length - 1)], this.gameObject.transform);
        cliente.name = "clienteModelo";
    }
}
