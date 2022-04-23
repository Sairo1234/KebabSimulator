using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPedido : MonoBehaviour
{
        
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
    //----------------------------------------- M�TODOS --------------------------------------//

    void Start()
    {
        
        panelPedido.SetActive(false);
        cliente = this.gameObject;
        //Activar componentes del canvas
        panelPedido.gameObject.GetComponent<Canvas>().enabled = true;
        panelPedido.gameObject.GetComponent<CanvasScaler>().enabled = true;
        panelPedido.gameObject.GetComponent<GraphicRaycaster>().enabled = true;
        panelPedido.gameObject.GetComponent<RestringirRotacionPanel>().enabled = true;
    }

    void Update()
    {
        rellenarPanelIngredientes();
    }

    void OnMouseEnter()
    {
        panelPedido.SetActive(true);
    }

    void OnMouseExit()
    {
        panelPedido.SetActive(false);
    }

    //--------------------------------------------------------------------------//
    //----------------------------- RELLENAR PANEL -----------------------------//

    public void rellenarPanelIngredientes()
    {
      texto_carne.text = cliente.GetComponent<Pedido>().carnePedido.nombre;
      texto_salsa.text = cliente.GetComponent<Pedido>().salsaPedido.nombre;
      texto_verdura.text = cliente.GetComponent<Pedido>().verduraPedido.nombre;
      
    }


   
}
