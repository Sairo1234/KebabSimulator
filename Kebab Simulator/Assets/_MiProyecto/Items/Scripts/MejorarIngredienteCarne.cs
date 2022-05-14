using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorarIngredienteCarne : MonoBehaviour
{
    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

    [Header("Info Ingrediente Mejorado")]
    public string[] nombresMejoras;
    public double[] costesMejoras;
    public double[] costesCompras;
    public GameObject[] modelosMejorasIngredientes;


    public void MejoraIngredienteNivelUno()
    {
        //Cambio de la Info del Ingredinte
        ingredienteCarne.nombre = nombresMejoras[1];
        ingredienteCarne.nivel++;

        //Cambio de modelo
        modelosMejorasIngredientes[0].SetActive(false);
        modelosMejorasIngredientes[1].SetActive(true);
    }

    public void MejoraIngredienteNivelDos()
    {
        ingredienteCarne.nombre = nombresMejoras[2];
        ingredienteCarne.nivel++;

        //Cambio de modelo
        modelosMejorasIngredientes[1].SetActive(false);
        modelosMejorasIngredientes[2].SetActive(true);
    }

    public void resetarIngrediente()
    {
        ingredienteCarne.nombre = nombresMejoras[0];
        ingredienteCarne.nivel = 0;
        modelosMejorasIngredientes[0].SetActive(true);
    }
}
