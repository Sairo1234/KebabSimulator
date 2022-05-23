using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerAlmacenCarnes : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

    [Header("Textos boton")]
    public Text textoCantidadAlmacen;
    public Text textoCantidadCocina;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        comprobarCompraIngrediente();
    }

    public void comprobarCompraIngrediente()
    {
        if (ingredienteCarne.estaComprado == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
            //textoCantidadAlmacen;

        }
    }

}
