using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSelectIngredienteSalsa : MonoBehaviour
{
    public GameObject botonReabastecer;
    public void limpiarIngredientesSelecionados()
    {
        foreach (GameObject botonSelecionado in botonReabastecer.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa)
        {
            botonSelecionado.GetComponent<SelectIngredienteSalsa>().iconoSelecionado.SetActive(false);
        }

        botonReabastecer.GetComponent<ReabastecerSalsa>().botonesSelecionadosIngredientesSalsa.Clear();
    }
}
