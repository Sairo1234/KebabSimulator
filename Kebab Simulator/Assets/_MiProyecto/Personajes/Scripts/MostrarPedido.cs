using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPedido : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    private GameObject kebabEnPreparacion;
    private GameObject cliente;

    //Panel
    [Header("Panel")]
    public GameObject panelPedido;

    //Textos
    [Header("Textos Panel")]
    public Text texto_carne;
    public Text texto_verdura;
    public Text texto_salsa;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Start()
    {
        kebabEnPreparacion = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
        cliente = this.gameObject;
        panelPedido.SetActive(false);
    }

    void Update()
    {
            rellenarPanelIngredientes();
    }

    void OnMouseEnter()
    {
        if (this.enabled)
            panelPedido.SetActive(true);
    }

    void OnMouseExit()
    {
        if (this.enabled)
            panelPedido.SetActive(false);
    }

    //--------------------------------------------------------------------------//
    //----------------------------- RELLENAR PANEL -----------------------------//

    public void rellenarPanelIngredientes()
    {
        comprobarCarne();
        comprobarVerdura();
        comprobarSalsa();
    }


    private void comprobarCarne()
    {
        try
        {
            texto_carne.text = cliente.GetComponent<Pedido>().carnePedido.nombre;
        }
        catch
        {
            texto_carne.text = "-";
        }
    }

    private void comprobarVerdura()
    {
        try
        {
            texto_verdura.text = cliente.GetComponent<Pedido>().verduraPedido.nombre;
        }
        catch
        {
            texto_verdura.text = "-";
        }
    }

    private void comprobarSalsa()
    {
        try
        {
            texto_salsa.text = cliente.GetComponent<Pedido>().salsaPedido.nombre;
        }
        catch
        {
            texto_salsa.text = "-";
        }
    }
}
