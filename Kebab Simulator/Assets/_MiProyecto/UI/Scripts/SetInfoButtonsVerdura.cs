using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInfoButtonsVerdura : MonoBehaviour
{
    ////----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;

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
        headerIngrediente.text = ingredienteVerdura.nombre;
        tipoIngrediente.text = "Tipo: " + "<b>" + ingredienteVerdura.tipo + "</b>";
        cantidadAlmacen.text = "<b>" + ingredienteVerdura.unidadesAlmacen.ToString() + "</b>" + " Unid. en Almacén";
        nivelMejora.text = "Mejora: " + "<b> Nivel " + ingredienteVerdura.DesbloqueoMejora.ToString() + "</b>";
        capacidadMax.text = "Capacidad: " + "<b>" + ingredienteVerdura.capacidadMaxIngrediente.ToString() + "</b>";
        costeUnidades.text = "Comprar Und. : " + ingredienteVerdura.costeCompraUnidades.ToString() + "K";
        if (ingredienteVerdura.nivel < 2)
        {
            costeMejora.text = "Mejorar : " + ingredienteVerdura.costeMejora.ToString() + "K";
        }
    }
}
