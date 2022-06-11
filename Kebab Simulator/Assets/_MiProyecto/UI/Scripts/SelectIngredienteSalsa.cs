using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIngredienteSalsa : MonoBehaviour
{
    ///----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Salsa")]
    public GameObject prefabIngredienteSalsaAlmacen;
    public Salsa ingredienteSalsaAlmacen;

    [Header("Boton almacen")]
    public Button BotonReabastecer; //Boton de reabstecer

    [Header("Icono Selecionado")]
    public GameObject iconoSelecionado; //Imagenes para el boton

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    public void seleccionarIngrediente()
    {
        switch (ingredienteSalsaAlmacen.nivel)
        {
            case 0:
                if (prefabIngredienteSalsaAlmacen.GetComponent<AñadirSalsa>().cantidad < 5 &&
                    ingredienteSalsaAlmacen.unidadesAlmacen >= ingredienteSalsaAlmacen.capacidadMaxIngrediente - prefabIngredienteSalsaAlmacen.gameObject.GetComponent<AñadirSalsa>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Add(this.gameObject);
                        iconoSelecionado.SetActive(true);
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Remove(this.gameObject);
                        iconoSelecionado.SetActive(false);
                    }
                }
                break;
            case 1:
                if (prefabIngredienteSalsaAlmacen.GetComponent<AñadirSalsa>().cantidad <= ingredienteSalsaAlmacen.capacidadMaxIngrediente / 2 &&
                    ingredienteSalsaAlmacen.unidadesAlmacen >= ingredienteSalsaAlmacen.capacidadMaxIngrediente - prefabIngredienteSalsaAlmacen.gameObject.GetComponent<AñadirSalsa>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Add(this.gameObject);
                        iconoSelecionado.SetActive(true);
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Remove(this.gameObject);
                        iconoSelecionado.SetActive(false);
                    }
                }
                break;
            case 2:
                if (prefabIngredienteSalsaAlmacen.GetComponent<AñadirSalsa>().cantidad <= ingredienteSalsaAlmacen.capacidadMaxIngrediente / 2 &&
                    ingredienteSalsaAlmacen.unidadesAlmacen >= ingredienteSalsaAlmacen.capacidadMaxIngrediente - prefabIngredienteSalsaAlmacen.gameObject.GetComponent<AñadirSalsa>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Add(this.gameObject);
                        iconoSelecionado.SetActive(true);
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Remove(this.gameObject);
                        iconoSelecionado.SetActive(false);
                    }
                }
                break;
        }
    }
}
