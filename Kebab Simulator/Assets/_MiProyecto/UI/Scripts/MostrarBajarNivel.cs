using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarBajarNivel : MonoBehaviour
{
    [Header("GUI Reputacion")]
    public GameObject bajarNivel;

    public Text nivelPrevio;
    public Text nivelNuevo;

    [Header("Jugador")]
    public GameObject jugador;

    private void OnEnable()
    {
        mostrarCamabioNivel();
        bajarNivel.SetActive(true);
        StartCoroutine(timerDesactivarBajarNivel());
    }

    public void mostrarCamabioNivel()
    {
        int nivelPrevioNum = jugador.GetComponent<ReputacionDinero>().Nivel + 1;
        nivelNuevo.text = jugador.GetComponent<ReputacionDinero>().Nivel.ToString();
        nivelPrevio.text = nivelPrevioNum.ToString();
    }

    IEnumerator timerDesactivarBajarNivel()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
