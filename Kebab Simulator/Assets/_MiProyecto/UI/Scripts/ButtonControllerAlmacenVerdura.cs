using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerAlmacenVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;
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
        headerNombreIngrediente.text = ingredienteVerdura.nombre;
        if (ingredienteVerdura.estaComprado == true)
        {
            headerNombreIngrediente.text = ingredienteVerdura.nombre;
            if (ingredienteVerdura.estaComprado == true)
            {
                this.gameObject.GetComponent<Button>().interactable = true;
                textoCantidadCocina.gameObject.SetActive(true);
                textoCantidadAlmacen.gameObject.SetActive(true);
                textoCantidadAlmacen.text = "Almacén: " + ingredienteVerdura.unidadesAlmacen.ToString();
                textoCantidadCocina.text = "Cocina: " + prefabIngrediente.GetComponent<AñadirVerdura>().cantidad + "/" +
                    ingredienteVerdura.capacidadMaxIngrediente.ToString();

            }
        }
    }
}
