using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarIngredienteSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente")]
    public Salsa ingredienteData;
    // public GameObject ingredientePrefab;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Awake()
    {
        ActivarIngrediente();
    }

    public void ActivarIngrediente()
    {
        if (ingredienteData.estaComprado == true && ingredienteData.estaDesbloqueado == true)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
