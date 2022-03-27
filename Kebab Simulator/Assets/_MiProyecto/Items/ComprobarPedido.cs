using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprobarPedido : MonoBehaviour
{
    public GameObject kebabParaComprobar;

    public Text text_carne;
    public Text text_verdura;
    public Text text_salsa;


    void Update()
    {


        if (GameObject.FindGameObjectWithTag("KebabEnPreparacion") != null)
        {
            kebabParaComprobar = GameObject.FindGameObjectWithTag("KebabEnPreparacion");

            comprobarCarne();
            comprobarVerdura();
            comprobarSalsa();
        }
        else
        {
            text_carne.color = Color.white;
            text_verdura.color = Color.white;
            text_salsa.color = Color.white;
        }

    }

    public void comprobarCarne()
    {
        if (kebabParaComprobar.GetComponent<Kebab>().contieneCarne() == true)
        {
            text_carne.color = Color.green;
        }
        else
        {
            text_carne.color = Color.white;
        }
    }
    public void comprobarVerdura()
    {
        if (kebabParaComprobar.GetComponent<Kebab>().contieneVerdura() == true)
        {
            text_verdura.color = Color.green;
        }
        else
        {
            text_verdura.color = Color.white;
        }
    }
    public void comprobarSalsa()
    {
        if (kebabParaComprobar.GetComponent<Kebab>().contieneSalsa() == true)
        {
            text_salsa.color = Color.green;
        }
        else
        {
            text_salsa.color = Color.white;
        }
    }

}

