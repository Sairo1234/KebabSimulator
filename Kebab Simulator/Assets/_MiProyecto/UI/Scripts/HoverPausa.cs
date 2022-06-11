using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPausa : MonoBehaviour
{
    private GameObject Boton;

    private void Start()
    {
        Boton = this.gameObject;
    }

    public void Hover()
    {
        Boton.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    public void ExitHover()
    {
        Boton.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
