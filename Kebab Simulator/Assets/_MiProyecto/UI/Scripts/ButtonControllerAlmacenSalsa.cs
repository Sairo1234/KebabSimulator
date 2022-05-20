using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerAlmacenSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Salsa")]
    public Salsa ingredienteSalsa;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        comprobarCompraIngrediente();
    }

    public void comprobarCompraIngrediente()
    {
        if (ingredienteSalsa.estaComprado == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
