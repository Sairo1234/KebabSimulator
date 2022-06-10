using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSelectIngredienteVerdura : MonoBehaviour
{
    public GameObject botonReabastecer;
    public void limpiarIngredientesSelecionados()
    {
        foreach (GameObject botonSelecionado in botonReabastecer.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura)
        {
            botonSelecionado.GetComponent<SelectIngredienteVerdura>().iconoSelecionado.SetActive(false);
        }

        botonReabastecer.GetComponent<ReabastecerVerdura>().botonesSelecionadosIngredientesVerdura.Clear();
    }
}
