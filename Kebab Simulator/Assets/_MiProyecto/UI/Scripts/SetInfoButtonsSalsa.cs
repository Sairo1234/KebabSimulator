using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInfoButtonsSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Salsa")]
    public Salsa ingredienteSalsa;

    [Header("Textos")]
    public Text headerIngrediente;
    public Text cantidadAlmacen;
    public Text tipoIngrediente;
    public Text nivelMejora;
    public Text capacidadMax;
    public Text costeUnidades;
    public Text costeMejora;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Update()
    {
        mostrarInformacionDeIngrediente();
    }

    public void mostrarInformacionDeIngrediente()
    {
        headerIngrediente.text = ingredienteSalsa.nombre;
        tipoIngrediente.text = "Tipo: " + "<b>" + ingredienteSalsa.tipo + "</b>";
        cantidadAlmacen.text = "<b>" + ingredienteSalsa.unidadesAlmacen.ToString() + "</b>" + " Unid. en Almacén";
        nivelMejora.text = "Mejora: " + "<b> Nivel " + ingredienteSalsa.DesbloqueoMejora.ToString() + "</b>";
        capacidadMax.text = "Capacidad: " + "<b>" + ingredienteSalsa.capacidadMaxIngrediente.ToString() + "</b>";
        costeUnidades.text = "Comprar Und. : " + ingredienteSalsa.costeCompraUnidades.ToString() + "K";
        if (ingredienteSalsa.nivel < 2)
        {
            costeMejora.text = "Mejorar : " + ingredienteSalsa.costeMejora.ToString() + "K";
        }
    }
}
