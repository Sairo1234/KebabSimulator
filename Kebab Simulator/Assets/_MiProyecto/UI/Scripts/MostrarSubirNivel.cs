using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarSubirNivel : MonoBehaviour
{
    [Header("GUI Reputacion")]
    public GameObject subirNivel;
    public GameObject subirNivelConfeti;

    public Text nivelPrevio;
    public Text nivelNuevo;

    [Header("Jugador")]
    public GameObject jugador;

    [Header("Audio")]
    public AudioSource SonidoSubirNivel;

    private void OnEnable()
    {
        mostrarCamabioNivel();
        subirNivel.SetActive(true);
        subirNivelConfeti.SetActive(true);
        SonidoSubirNivel.Play();
        StartCoroutine(timerDesactivarSubirNivel());
    }

    private void OnDisable()
    {
        subirNivel.SetActive(false);
        subirNivelConfeti.SetActive(false);
    }

    public void mostrarCamabioNivel()
    {
        int nivelPrevioNum = jugador.GetComponent<ReputacionDinero>().Nivel - 1;
        nivelNuevo.text = jugador.GetComponent<ReputacionDinero>().Nivel.ToString();
        nivelPrevio.text = nivelPrevioNum.ToString();
    }


    IEnumerator timerDesactivarSubirNivel()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
