using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaController : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip MusicaJugeo;
    public AudioClip MusicaTienda;
    public AudioClip[] AmbienteInicio;
    
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        //PlayMusicaJuego();
    }

    public void PlayMusicaJuego()
    {
        if (audiosource != null)
        {
            audiosource.clip = MusicaJugeo;
            audiosource.loop = true;
            audiosource.Play();
        }
    }

    public void PlayMusicaTienda()
    {
        if (audiosource != null)
        {
            audiosource.clip = MusicaTienda;
            audiosource.loop = true;
            audiosource.Play();
        }
    }
    
    public void PlayAmbienteInicio()
    {
        if (audiosource != null)
        {
            audiosource.clip = AmbienteInicio[Random.Range(0, AmbienteInicio.Length)];
            audiosource.loop = false;
            audiosource.Play();
        }
    }
}
