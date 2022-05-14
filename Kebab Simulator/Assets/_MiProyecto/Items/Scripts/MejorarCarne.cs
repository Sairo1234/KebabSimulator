using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorarCarne : MonoBehaviour
{
    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

    [Header("Info Ingrediente Mejorado")]
    public string[] nombresMejoras = new string[3];
    public int[] DesbloqueoCompra = new int[3];
    public int[] DesbloqueoMejora = new int[3];
    public double[] costesMejoras = new double[3];
    public double[] costesCompras = new double[3];
    public double[] precioEntrega = new double[3];
    public GameObject[] modelosMejorasIngredientes = new GameObject[3];


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
        modelosMejorasIngredientes[1].SetActive(false);
        modelosMejorasIngredientes[2].SetActive(false);
    }
}
