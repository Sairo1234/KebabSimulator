using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarIngredienteCarne : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente")]
    public Carne ingredienteData;
    // public GameObject ingredientePrefab;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- M�TODOS --------------------------------------//

    private void Awake()
    {
        ActivarIngrediente();
    }

    public void ActivarIngrediente()
    {
        if(ingredienteData.estaComprado == true && ingredienteData.estaDesbloqueado == true)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}