using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPausaController : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelVolumen;

    public void mostrarVolumen(){
        panelPausa.SetActive(false);
        panelVolumen.SetActive(true);
    }

    public void ocultarVolumen()
    {
        panelPausa.SetActive(true);
        panelVolumen.SetActive(false);
    }
}
