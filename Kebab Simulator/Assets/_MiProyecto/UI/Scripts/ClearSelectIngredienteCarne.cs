using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSelectIngredienteCarne : MonoBehaviour
{
    public GameObject botonReabastecer;
    public void limpiarIngredientesSelecionados()
    {
        foreach (GameObject botonSelecionado in botonReabastecer.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne)
        {
            botonSelecionado.GetComponent<SelectIngredienteCarne>().iconoSelecionado.SetActive(false);
        }

        botonReabastecer.GetComponent<ReabastecerCarne>().botonesSelecionadosIngredientesCarne.Clear();
    }
}
