using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarNumeroClientes : MonoBehaviour
{
    [Header("GameManager")]
    public GameObject gameManager;

    [Header("Texto HUD")]
    public Text textoNumeroClientes;

    void Update()
    {
        mostrarNumeroClientesMax();
    }

    public void mostrarNumeroClientesMax()
    {
        textoNumeroClientes.text = gameManager.GetComponent<GameManager>().clientesContador + "/" + gameManager.GetComponent<GameManager>().clientesMax;


    }
}
