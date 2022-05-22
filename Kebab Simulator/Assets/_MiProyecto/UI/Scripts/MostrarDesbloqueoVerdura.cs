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

    ///----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Update()
    {
        mostrarInformacionDesbloqueo();
    }

    public void mostrarInformacionDesbloqueo()
    {
        nivelDesbloqueo.text = "Nivel:" + ingredienteVerdura.DesbloqueoCompra.ToString();
        costeCompra.text = ingredienteVerdura.costeCompra.ToString() + " K";
    }
}
