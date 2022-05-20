using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReabastecerSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingredientes selecionados ")]
    public List<GameObject> botonesSelecionadosIngredientesSalsa = new List<GameObject>();

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    public void reabastecerIngredienteSalsa()
    {
        foreach (GameObject BotonIngrediente in botonesSelecionadosIngredientesSalsa)
        {
            int cantidadParaRellenar = BotonIngrediente.gameObject.GetComponent<SelectIngredienteSalsa>().ingredienteSalsaAlmacen.capacidadMaxIngrediente -
            BotonIngrediente.gameObject.GetComponent<SelectIngredienteSalsa>().prefabIngredienteSalsaAlmacen.GetComponent<AñadirSalsa>().cantidad;

            for (int i = 1; i <= cantidadParaRellenar; i++)
            {
                BotonIngrediente.gameObject.GetComponent<SelectIngredienteSalsa>().prefabIngredienteSalsaAlmacen.GetComponent<AñadirSalsa>().cantidad++;
                BotonIngrediente.gameObject.GetComponent<SelectIngredienteSalsa>().ingredienteSalsaAlmacen.unidadesAlmacen--;
            }
            BotonIngrediente.GetComponent<Image>().sprite = BotonIngrediente.GetComponent<SelectIngredienteSalsa>().backgroundsBotones[1];
        }

        botonesSelecionadosIngredientesSalsa.Clear();

    }
}
