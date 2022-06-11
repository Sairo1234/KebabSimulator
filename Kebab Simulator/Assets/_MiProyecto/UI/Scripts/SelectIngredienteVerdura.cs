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

    [Header("Icono Selecionado")]
    public GameObject iconoSelecionado; //Imagenes para el boton

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- M�TODOS --------------------------------------//

    public void seleccionarIngrediente()
    {
        switch (ingredienteVerduraAlmacen.nivel)
        {
            case 0:
                if (prefabIngredienteVerduraAlmacen.GetComponent<A�adirVerdura>().cantidad < 5 &&
                    ingredienteVerduraAlmacen.unidadesAlmacen >= ingredienteVerduraAlmacen.capacidadMaxIngrediente - prefabIngredienteVerduraAlmacen.gameObject.GetComponent<A�adirVerdura>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Add(this.gameObject);
                        iconoSelecionado.SetActive(true);
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Remove(this.gameObject);
                        iconoSelecionado.SetActive(false);
                    }
                }
                break;
            case 1:
                if (prefabIngredienteVerduraAlmacen.GetComponent<A�adirVerdura>().cantidad <= ingredienteVerduraAlmacen.capacidadMaxIngrediente / 2 &&
                    ingredienteVerduraAlmacen.unidadesAlmacen >= ingredienteVerduraAlmacen.capacidadMaxIngrediente - prefabIngredienteVerduraAlmacen.gameObject.GetComponent<A�adirVerdura>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Add(this.gameObject);
                        iconoSelecionado.SetActive(true);
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Remove(this.gameObject);
                        iconoSelecionado.SetActive(false);
                    }
                }
                break;
            case 2:
                if (prefabIngredienteVerduraAlmacen.GetComponent<A�adirVerdura>().cantidad <= ingredienteVerduraAlmacen.capacidadMaxIngrediente / 2 &&
                    ingredienteVerduraAlmacen.unidadesAlmacen >= ingredienteVerduraAlmacen.capacidadMaxIngrediente - prefabIngredienteVerduraAlmacen.gameObject.GetComponent<A�adirVerdura>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Add(this.gameObject);
                        iconoSelecionado.SetActive(true);
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Remove(this.gameObject);
                        iconoSelecionado.SetActive(false);
                    }
                }
                break;
        }
    }
}
