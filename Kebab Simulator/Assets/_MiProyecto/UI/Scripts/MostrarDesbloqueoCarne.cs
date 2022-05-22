using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarDesbloqueoCarne : MonoBehaviour
{
    ////----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

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
        nivelDesbloqueo.text = "Nivel:" + ingredienteCarne.DesbloqueoCompra.ToString();
        costeCompra.text = ingredienteCarne.costeCompra.ToString() + " K";
    }
}
