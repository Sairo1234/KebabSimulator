using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReabastecerVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingredientes selecionados ")]
    public List<GameObject> botonesSelecionadosIngredientesVerdura = new List<GameObject>();

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    public void reabastecerIngredienteVerdura()
    {
        foreach (GameObject BotonIngrediente in botonesSelecionadosIngredientesVerdura)
        {
            int cantidadParaRellenar = BotonIngrediente.gameObject.GetComponent<SelectIngredienteVerdura>().ingredienteVerduraAlmacen.capacidadMaxIngrediente -
            BotonIngrediente.gameObject.GetComponent<SelectIngredienteVerdura>().prefabIngredienteVerduraAlmacen.GetComponent<AñadirVerdura>().cantidad;

            for (int i = 1; i <= cantidadParaRellenar; i++)
            {
                BotonIngrediente.gameObject.GetComponent<SelectIngredienteVerdura>().prefabIngredienteVerduraAlmacen.GetComponent<AñadirVerdura>().cantidad++;
                BotonIngrediente.gameObject.GetComponent<SelectIngredienteVerdura>().ingredienteVerduraAlmacen.unidadesAlmacen--;
            }
            BotonIngrediente.GetComponent<Image>().sprite = BotonIngrediente.GetComponent<SelectIngredienteVerdura>().backgroundsBotones[1];
        }

        botonesSelecionadosIngredientesVerdura.Clear();

    }
}
