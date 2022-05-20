using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloquearVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;

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
        if (nivelJugador == ingredienteVerdura.DesbloqueoCompra)
        {
            ingredienteVerdura.estaDesbloqueado = true;
            botonComprarIngrediente.interactable = true;
        }
    }
}
