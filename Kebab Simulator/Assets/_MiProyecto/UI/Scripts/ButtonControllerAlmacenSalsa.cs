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
    //----------------------------------------- MÉTODOS --------------------------------------//

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
            textoCantidadAlmacen.text = "Almacén: " + ingredienteSalsa.unidadesAlmacen.ToString();
            textoCantidadCocina.text = "Cocina: " + prefabIngrediente.GetComponent<AñadirSalsa>().cantidad + "/" +
                ingredienteSalsa.capacidadMaxIngrediente.ToString();

        }
    }
}
