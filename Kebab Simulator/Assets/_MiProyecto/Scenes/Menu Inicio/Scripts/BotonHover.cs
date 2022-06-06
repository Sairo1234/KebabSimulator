using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonHover : MonoBehaviour
{
    private GameObject Boton;

    private void Start()
    {
        Boton = this.gameObject;
    }

    public void Hover()
    {
        Boton.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Boton.transform.GetChild(0).GetComponent<Text>().color = new Color(147f / 255f, 54f / 255f, 41f / 255f);
    }
    public void ExitHover()
    {
        Boton.transform.localScale = new Vector3(1f, 1f, 1f);

        Boton.transform.GetChild(0).GetComponent<Text>().color = new Color(50f / 255f, 50f / 255f, 50f / 255f);


    }
}
