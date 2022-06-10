using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIngredienteCarne : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public GameObject prefabIngredienteCarneAlmacen;
    public Carne ingredienteCarneAlmacen;

    [Header("Boton almacen")]
    public Button BotonReabastecer; //Boton de reabstecer

    [Header("Icono Selecionado")]
    public GameObject iconoSelecionado; //Imagenes para el boton

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- M�TODOS --------------------------------------//

    public void seleccionarIngrediente()
    {
        switch (ingredienteCarneAlmacen.nivel)
        {
            case 0:
                if (prefabIngredienteCarneAlmacen.GetComponent<A�adirCarne>().cantidad < 5 &&
                    ingredienteCarneAlmacen.unidadesAlmacen >= ingredienteCarneAlmacen.capacidadMaxIngrediente - prefabIngredienteCarneAlmacen.gameObject.GetComponent<A�adirCarne>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne.Add(this.gameObject);
                        iconoSelecionado.SetActive(true);
                        //this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[0];
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne.Remove(this.gameObject);
                        iconoSelecionado.SetActive(false);
                        //this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[1];
                    }
                }
                break;
            case 1:
                if (prefabIngredienteCarneAlmacen.GetComponent<A�adirCarne>().cantidad <= ingredienteCarneAlmacen.capacidadMaxIngrediente / 2 && 
                    ingredienteCarneAlmacen.unidadesAlmacen >= ingredienteCarneAlmacen.capacidadMaxIngrediente - prefabIngredienteCarneAlmacen.gameObject.GetComponent<A�adirCarne>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne.Add(this.gameObject);
                        iconoSelecionado.SetActive(true);
                        //this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[0];
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne.Remove(this.gameObject);
                        iconoSelecionado.SetActive(false);
                        //this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[1];
                    }
                }
                break;
            case 2:
                if (prefabIngredienteCarneAlmacen.GetComponent<A�adirCarne>().cantidad <= ingredienteCarneAlmacen.capacidadMaxIngrediente / 2 &&
                    ingredienteCarneAlmacen.unidadesAlmacen >= ingredienteCarneAlmacen.capacidadMaxIngrediente - prefabIngredienteCarneAlmacen.gameObject.GetComponent<A�adirCarne>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne.Add(this.gameObject);
                        iconoSelecionado.SetActive(true);
                        //this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[0];
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne.Remove(this.gameObject);
                        iconoSelecionado.SetActive(false);
                        //this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[1];
                    }
                }
                break;
        }
    }
}
