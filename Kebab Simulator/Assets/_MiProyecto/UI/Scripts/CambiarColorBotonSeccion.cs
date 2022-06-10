using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarColorBotonSeccion : MonoBehaviour
{
    [Header("Botones")]
    public Button seccion1;
    public Button seccion2;
    public Button seccion3;

    public void cambioColorBoton()
    {
        seccion1.GetComponent<Image>().color = new Color(215f / 255f, 58f / 255f, 58f / 255f);
        seccion2.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
        seccion3.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
    }
}
