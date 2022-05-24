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
    public Sprite[] backgroundsBotones; //Imagenes para el boton

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- M�TODOS --------------------------------------//

    public void seleccionarIngrediente()
    {
        switch (ingredienteSalsaAlmacen.nivel)
        {
            case 0:
                if (prefabIngredienteSalsaAlmacen.GetComponent<A�adirSalsa>().cantidad < 5 &&
                    ingredienteSalsaAlmacen.unidadesAlmacen <= ingredienteSalsaAlmacen.capacidadMaxIngrediente - prefabIngredienteSalsaAlmacen.gameObject.GetComponent<A�adirSalsa>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Add(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[0];
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Remove(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[1];
                    }
                }
                break;
            case 1:
                if (prefabIngredienteSalsaAlmacen.GetComponent<A�adirSalsa>().cantidad <= ingredienteSalsaAlmacen.capacidadMaxIngrediente / 2 &&
                    ingredienteSalsaAlmacen.unidadesAlmacen <= ingredienteSalsaAlmacen.capacidadMaxIngrediente - prefabIngredienteSalsaAlmacen.gameObject.GetComponent<A�adirSalsa>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Add(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[0];
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Remove(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[1];
                    }
                }
                break;
            case 2:
                if (prefabIngredienteSalsaAlmacen.GetComponent<A�adirSalsa>().cantidad <= ingredienteSalsaAlmacen.capacidadMaxIngrediente / 2 &&
                    ingredienteSalsaAlmacen.unidadesAlmacen <= ingredienteSalsaAlmacen.capacidadMaxIngrediente - prefabIngredienteSalsaAlmacen.gameObject.GetComponent<A�adirSalsa>().cantidad)
                {
                    if (!BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Contains(this.gameObject))
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Add(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[0];
                    }
                    else
                    {
                        BotonReabastecer.gameObject.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Remove(this.gameObject);
                        this.gameObject.GetComponent<Image>().sprite = backgroundsBotones[1];
                    }
                }
                break;
        }
    }
}
