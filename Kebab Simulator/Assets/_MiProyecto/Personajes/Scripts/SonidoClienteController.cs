using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoClienteController : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioSource audioSourceDinero;

    public AudioClip[] audioClipContento;
    public AudioClip[] audioClipFrustrado;
    public AudioClip[] audioClipPidiendo;
    public AudioClip[] audioClipImpaciente;
    public AudioClip[] audioClipDinero;

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

            audioSource.loop = false;
            audioSource.Play();
        }
    }

    public void PlayFrustrado()
    {
        if (audioSource != null)
        {
            int audioRandom = Random.Range(0, audioClipFrustrado.Length);
            audioSource.clip = audioClipFrustrado[audioRandom];

            audioSource.loop = false;
            audioSource.Play();
        }
    }

    public void PlayPidiendo()
    {
        if (audioSource != null)
        {
            int audioRandom = Random.Range(0, audioClipPidiendo.Length);
            audioSource.clip = audioClipPidiendo[audioRandom];

            audioSource.loop = true;
            audioSource.Play();

        }
    }


    public void PlayImpaciente()
    {
        if (audioSource != null)
        {
            int audioRandom = Random.Range(0, audioClipImpaciente.Length);
            audioSource.clip = audioClipImpaciente[audioRandom];

            audioSource.loop = false;
            audioSource.Play();
        }
    }

    public void PlayDinero()
    {
        if (audioSource != null)
        {
            int audioRandom = Random.Range(0, audioClipDinero.Length);
            audioSourceDinero.clip = audioClipDinero[audioRandom];

            audioSource.loop = false;
            audioSourceDinero.Play();
        }
    }
}
