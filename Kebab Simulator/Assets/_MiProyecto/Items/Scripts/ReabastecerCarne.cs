using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReabastecerCarne : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingredientes selecionados ")]
    public List<GameObject> botonesSelecionadosIngredientesCarne = new List<GameObject>();


    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//


    public void reabastecerIngredienteCarne()
    {
        foreach (GameObject BotonIngrediente in botonesSelecionadosIngredientesCarne)
        {
            int cantidadParaRellenar = BotonIngrediente.gameObject.GetComponent<SelectIngredienteCarne>().ingredienteCarneAlmacen.capacidadMaxIngrediente -
            BotonIngrediente.gameObject.GetComponent<SelectIngredienteCarne>().prefabIngredienteCarneAlmacen.GetComponent<AñadirCarne>().cantidad;

            for (int i = 1; i <= cantidadParaRellenar; i++)
            {
                BotonIngrediente.gameObject.GetComponent<SelectIngredienteCarne>().prefabIngredienteCarneAlmacen.GetComponent<AñadirCarne>().cantidad++;
                BotonIngrediente.gameObject.GetComponent<SelectIngredienteCarne>().ingredienteCarneAlmacen.unidadesCocina++;
                BotonIngrediente.gameObject.GetComponent<SelectIngredienteCarne>().ingredienteCarneAlmacen.unidadesAlmacen--;
            }
            BotonIngrediente.GetComponent<SelectIngredienteCarne>().iconoSelecionado.SetActive(false);
        }

        //Limpiar Botones
        botonesSelecionadosIngredientesCarne.Clear();

    }

}
