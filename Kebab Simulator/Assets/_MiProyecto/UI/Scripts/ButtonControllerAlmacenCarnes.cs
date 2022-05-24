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
        headerNombreIngrediente.text = ingredienteCarne.nombre;
        if (ingredienteCarne.estaComprado == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
            textoCantidadCocina.gameObject.SetActive(true);
            textoCantidadAlmacen.gameObject.SetActive(true);
            textoCantidadAlmacen.text = "Almacén: " + ingredienteCarne.unidadesAlmacen.ToString();
            textoCantidadCocina.text = "Cocina: " + prefabIngrediente.GetComponent<AñadirCarne>().cantidad + "/" +
                ingredienteCarne.capacidadMaxIngrediente.ToString();

        }
    }

}
