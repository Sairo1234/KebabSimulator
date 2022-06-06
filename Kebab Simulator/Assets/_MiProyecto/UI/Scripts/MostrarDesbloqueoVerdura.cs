using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarDesbloqueoVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;

    [Header("Textos")]
    public Text nivelDesbloqueo;
    public Text costeCompra;
    public Text nombreIngrediente;

    ///----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Update()
    {
        mostrarInformacionDesbloqueo();
    }

    public void mostrarInformacionDesbloqueo()
    {
        nombreIngrediente.text = ingredienteVerdura.nombre;
        nivelDesbloqueo.text = ingredienteVerdura.DesbloqueoCompra.ToString();
        costeCompra.text = ingredienteVerdura.costeCompra.ToString();
    }
}
