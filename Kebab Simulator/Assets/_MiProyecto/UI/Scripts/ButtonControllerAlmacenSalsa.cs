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
    public GameObject prefabIngrediente;

    [Header("Textos boton")]
    public Text textoCantidadAlmacen;
    public Text textoCantidadCocina;
    public Text headerNombreIngrediente;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- M�TODOS --------------------------------------//

    private void Update()
    {
        comprobarCompraIngrediente();
    }

    public void comprobarCompraIngrediente()
    {
        headerNombreIngrediente.text = ingredienteSalsa.nombre;
        if (ingredienteSalsa.estaComprado == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
            textoCantidadCocina.gameObject.SetActive(true);
            textoCantidadAlmacen.gameObject.SetActive(true);
            textoCantidadAlmacen.text = "Almac�n: " + ingredienteSalsa.unidadesAlmacen.ToString();
            textoCantidadCocina.text = "Cocina: " + prefabIngrediente.GetComponent<A�adirSalsa>().cantidad + "/" +
                ingredienteSalsa.capacidadMaxIngrediente.ToString();

        }
    }
}
