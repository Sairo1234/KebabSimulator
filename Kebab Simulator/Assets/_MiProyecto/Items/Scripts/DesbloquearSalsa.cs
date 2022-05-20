using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloquearSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Salsa")]
    public Salsa ingredienteSalsa;

    [Header("Jugador")]
    public GameObject jugador;
    public int nivelJugador;

    [Header("Boton Compra")]
    public Button botonComprarIngrediente;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        nivelJugador = jugador.GetComponent<ReputacionDinero>().Nivel;
        desbloquearIngrediente();
    }

    public void desbloquearIngrediente()
    {
        if (nivelJugador == ingredienteSalsa.DesbloqueoCompra)
        {
            ingredienteSalsa.estaDesbloqueado = true;
            botonComprarIngrediente.interactable = true;
        }
    }
}
