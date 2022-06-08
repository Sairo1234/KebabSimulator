using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BarraVolumen : MonoBehaviour
{
    public AudioMixer Mixer;

    public void VolEfectos(float nivel)
    {
        Mixer.SetFloat("SFX", Mathf.Log10(nivel) * 20);
    }

    public void VolMusica(float nivel)
    {
        Mixer.SetFloat("Musica", Mathf.Log10(nivel) * 20);
    }

    public void volDialogos(float nivel)
    {
        Mixer.SetFloat("Dialogos", Mathf.Log10(nivel) * 20);
        //Mixer.GetFloat("Dialogos", out 0);
    }

    public void Volumenes(float nivel)
    {
        Mixer.SetFloat("Master", Mathf.Log10(nivel) * 20);
    }
}
