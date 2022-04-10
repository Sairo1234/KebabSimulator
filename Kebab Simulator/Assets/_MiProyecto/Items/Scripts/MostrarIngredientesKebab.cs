using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarIngredientesKebab : MonoBehaviour
{

    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    private GameObject kebab;

    //Panel
    [Header("Panel")]
    public GameObject panelIngredientes;
    
    //Textos
    [Header("Textos Panel")]
    public Text texto_carne;
    public Text texto_verdura;
    public Text texto_salsa;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Start()
    {
        kebab = this.gameObject;
        panelIngredientes.SetActive(false);

        //Activar componentes del canvas
        panelIngredientes.gameObject.GetComponent<Canvas>().enabled = true;
        panelIngredientes.gameObject.GetComponent<CanvasScaler>().enabled = true;
        panelIngredientes.gameObject.GetComponent<GraphicRaycaster>().enabled = true;
        panelIngredientes.gameObject.GetComponent<RestringirRotacionPanel>().enabled = true;
    }

    void Update()
    {
        rellenarPanelIngredientes();
    }

    void OnMouseEnter()
    {
        panelIngredientes.SetActive(true);
    }

    void OnMouseExit()
    {
        panelIngredientes.SetActive(false);
    }

    //--------------------------------------------------------------------------//
    //----------------------------- RELLENAR PANEL -----------------------------//

    public void rellenarPanelIngredientes()
    {
        texto_carne.text = kebab.GetComponent<Kebab>().Carne;
        texto_verdura.text = kebab.GetComponent<Kebab>().Verdura;
        texto_salsa.text = kebab.GetComponent<Kebab>().Salsa;
    }
}
