using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInfoButtonsCarne : MonoBehaviour
{
    ////----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

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
        headerIngrediente.text = ingredienteCarne.nombre;
        tipoIngrediente.text = "Tipo: " + "<b>" + ingredienteCarne.tipo + "</b>";
        cantidadAlmacen.text = "<b>" + ingredienteCarne.unidadesAlmacen.ToString() + "</b>" + " Unid. en Almacén";
        nivelMejora.text = "Mejora: " + "<b> Nivel " + ingredienteCarne.DesbloqueoMejora.ToString() + "</b>";
        capacidadMax.text = "Capacidad: " + "<b>" + ingredienteCarne.capacidadMaxIngrediente.ToString() + "</b>";
        costeUnidades.text = "Comprar Und. : " + ingredienteCarne.costeCompraUnidades.ToString() + "K";
        if (ingredienteCarne.nivel <2)
        {
            costeMejora.text = "Mejorar : " + ingredienteCarne.costeMejora.ToString() + "K";
        }
    }
}
