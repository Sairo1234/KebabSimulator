using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloquearCarne : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

    [Header("Jugador")]
    public GameObject jugador;
    public int nivelJugador;

    [Header("Boton Compra")]
    public Button botonComprarIngrediente;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Start()
    {
        nivelJugador = jugador.GetComponent<ReputacionDinero>().Nivel;
        desbloquearIngrediente();
    }

    public void desbloquearIngrediente()
    {
        if(nivelJugador >= ingredienteCarne.DesbloqueoCompra)
        {
            ingredienteCarne.estaDesbloqueado = true;
            botonComprarIngrediente.interactable = true;
        }
    }

}
