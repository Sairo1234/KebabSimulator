using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoJugadorController : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] audioClipContento;
    public AudioClip[] audioClipFrustrado;
    public AudioClip[] audioClipTomandoNota;
    public AudioClip[] audioClipTriste;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayContento()
    {
        if (audioSource != null)
        {
            int audioRandom = Random.Range(0, audioClipContento.Length);
            audioSource.clip = audioClipContento[audioRandom];
            audioSource.Play();
        }
    }

    public void PlayFrustrado()
    {
        if (audioSource != null)
        {
            int audioRandom = Random.Range(0, audioClipFrustrado.Length);
            audioSource.clip = audioClipFrustrado[audioRandom];
            audioSource.Play();
        }
    }

    public void PlayTomandoNota()
    {
        if (audioSource != null)
        {
            int audioRandom = Random.Range(0, audioClipTomandoNota.Length);
            audioSource.clip = audioClipTomandoNota[audioRandom];
            audioSource.Play();
        }
    }

    public void PlayTriste()
    {
        if (audioSource != null)
        {
            int audioRandom = Random.Range(0, audioClipTriste.Length);
            audioSource.clip = audioClipTriste[audioRandom];
            audioSource.Play();
        }
    }


}
