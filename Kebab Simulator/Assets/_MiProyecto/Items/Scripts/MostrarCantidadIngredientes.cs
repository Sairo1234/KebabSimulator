using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarCantidadIngredientes : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //Panel
    [Header("Ingrediente")]
    public GameObject ingrediente;

    //Panel
    [Header("Panel")]
    public GameObject panelCantidadEstacion;

    //Textos
    [Header("Textos Panel")]
    public Text texto_cantidad;
    public Text texto_header;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Update()
    {
        rellenarPanelCantidad();
    }

    void OnMouseEnter()
    {
        panelCantidadEstacion.SetActive(true);
    }

    void OnMouseExit()
    {
        panelCantidadEstacion.SetActive(false);
    }

    //--------------------------------------------------------------------------//
    //----------------------------- RELLENAR PANEL -----------------------------//

    public void rellenarPanelCantidad()
    {
        

        if(ingrediente.GetComponent<AñadirCarne>())
        {
            texto_header.text = ingrediente.GetComponent<AñadirCarne>().IngredienteData.nombre.ToString();
            texto_cantidad.text = ingrediente.GetComponent<AñadirCarne>().cantidad.ToString();
        }
        else if (ingrediente.GetComponent<AñadirVerdura>())
        {
            texto_header.text = ingrediente.GetComponent<AñadirVerdura>().IngredienteData.nombre.ToString();
            texto_cantidad.text = ingrediente.GetComponent<AñadirVerdura>().cantidad.ToString();
        }
        else if (ingrediente.GetComponent<AñadirSalsa>())
        {
            texto_header.text = ingrediente.GetComponent<AñadirSalsa>().IngredienteData.nombre.ToString();
            texto_cantidad.text = ingrediente.GetComponent<AñadirSalsa>().cantidad.ToString();
        }

    }
}
