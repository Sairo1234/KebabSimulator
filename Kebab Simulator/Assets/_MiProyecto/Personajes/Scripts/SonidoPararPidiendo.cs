using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoPararPidiendo : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject jugador;

    private void Start()
    {
        audioSource = this.gameObject.GetComponentInChildren<AudioSource>();
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    public void StopPidiendo()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            jugador.GetComponent<AudioSource>().Stop();
        }
    }
}