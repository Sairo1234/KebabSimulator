using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIngredienteVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public GameObject prefabIngredienteVerduraAlmacen;
    public Verdura ingredienteVerduraAlmacen;

    [Header("Boton almacen")]
    public Button BotonReabastecer; //Boton de reabstecer
    public Sprite[] backgroundsBotones; //Imagenes para el boton

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    public void seleccionarIngrediente()
    {
        switch (ingredienteVerduraAlmacen.nivel)
        {
            case 0:
                if (prefabIngredienteVerduraAlmacen.GetComponent<AñadirVerdura>().cantidad < 5)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Add(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[0];
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Remove(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[1];
                    }
                }
                break;
            case 1:
                if (prefabIngredienteVerduraAlmacen.GetComponent<AñadirVerdura>().cantidad <= ingredienteVerduraAlmacen.capacidadMaxIngrediente / 2)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Add(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[0];
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Remove(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[1];
                    }
                }
                break;
            case 2:
                if (prefabIngredienteVerduraAlmacen.GetComponent<AñadirVerdura>().cantidad <= ingredienteVerduraAlmacen.capacidadMaxIngrediente / 2)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Add(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[0];
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Remove(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[1];
                    }
                }
                break;
        }
    }
}
