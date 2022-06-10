using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaHover : MonoBehaviour
{
    private GameObject Boton;
    public AudioSource audioHover;

    private void Start()
    {
        Boton = this.gameObject;
    }

    public void Hover()
    {
        Boton.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        audioHover.Play();
    }
    public void ExitHover()
    {
        Boton.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
