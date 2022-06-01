using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInfoResumenDia : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("GameObject")]
    public GameObject gameManager;

    [Header("Textos")]
    public Text headerResumen;
    public Text textoKebabsPerfectos;
    public Text textoKebabsIncorrectos;
    public Text textoClientesPerdidos;
    public Text textoClientesRechazados;
    public Text textoDineroGanado;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Update()
    {
        mostrarInformacionDia();
    }

    public void mostrarInformacionDia()
    {
        //Header del Resumen
        headerResumen.text = "RESUMEN  DIA " + gameManager.GetComponent<GameManager>().numDia.ToString();

        //Textos clientes
        textoClientesPerdidos.text = gameManager.GetComponent<GameManager>().clientesPerdidos.ToString();
        textoClientesRechazados.text = gameManager.GetComponent<GameManager>().clientesRechazados.ToString();

        //Textos kebabs
        textoKebabsPerfectos.text = gameManager.GetComponent<GameManager>().numKebabsPerfectos.ToString();
        textoKebabsIncorrectos.text = gameManager.GetComponent<GameManager>().numKebabsIncorrectos.ToString();


    }
}
