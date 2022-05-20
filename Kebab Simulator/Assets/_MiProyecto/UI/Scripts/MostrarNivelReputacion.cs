using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarNivelReputacion : MonoBehaviour
{
    [Header("Jugador")]
    public GameObject jugador;

    [Header("Texto HUD")]
    public Text textoDinero;
    public Text textoNivel;

    void Update()
    {
        mostrarNivelReputacionHUD();
    }

    public void mostrarNivelReputacionHUD()
    {
        textoDinero.text = jugador.GetComponent<ReputacionDinero>().Dinero.ToString();
        textoNivel.text = jugador.GetComponent<ReputacionDinero>().Nivel.ToString();
    }
}
