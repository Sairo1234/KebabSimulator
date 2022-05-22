using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarDesbloqueoSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Salsa")]
    public Salsa ingredienteSalsa;

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
        nivelDesbloqueo.text = "Nivel:" + ingredienteSalsa.DesbloqueoCompra.ToString();
        costeCompra.text = ingredienteSalsa.costeCompra.ToString() + " K";
    }
}
