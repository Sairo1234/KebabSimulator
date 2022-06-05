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
    public Text nombreIngrediente;

    ///----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Update()
    {
        mostrarInformacionDesbloqueo();
    }

    public void mostrarInformacionDesbloqueo()
    {
        nombreIngrediente.text = ingredienteCarne.nombre;
        nivelDesbloqueo.text = ingredienteCarne.DesbloqueoCompra.ToString();
        costeCompra.text = ingredienteCarne.costeCompra.ToString();
    }
}
