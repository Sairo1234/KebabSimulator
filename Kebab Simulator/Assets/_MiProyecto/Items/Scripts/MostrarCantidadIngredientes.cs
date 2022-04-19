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
    //----------------------------------------- M�TODOS --------------------------------------//

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
        

        if(ingrediente.GetComponent<A�adirCarne>())
        {
            texto_header.text = ingrediente.GetComponent<A�adirCarne>().IngredienteData.nombre.ToString();
            texto_cantidad.text = ingrediente.GetComponent<A�adirCarne>().cantidad.ToString();
        }
        else if (ingrediente.GetComponent<A�adirVerdura>())
        {
            texto_header.text = ingrediente.GetComponent<A�adirVerdura>().IngredienteData.nombre.ToString();
            texto_cantidad.text = ingrediente.GetComponent<A�adirVerdura>().cantidad.ToString();
        }
        else if (ingrediente.GetComponent<A�adirSalsa>())
        {
            texto_header.text = ingrediente.GetComponent<A�adirSalsa>().IngredienteData.nombre.ToString();
            texto_cantidad.text = ingrediente.GetComponent<A�adirSalsa>().cantidad.ToString();
        }

    }
}
