using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarCarne : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

    [Header("Prefab del Ingrediente")]
    public GameObject prefabIngrediente;

    [Header("Jugador")]
    public GameObject jugador;
    public float dineroJugador;

    [Header("Boton Compra")]
    public GameObject[] botonesTiendaIngrediente;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        dineroJugador = jugador.GetComponent<ReputacionDinero>().Dinero;
    }

    public void comprarIngrediente()
    {
        if (ingredienteCarne.estaDesbloqueado == true && dineroJugador >= ingredienteCarne.costeCompra)
        {
            jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteCarne.costeCompra);

            ingredienteCarne.estaComprado = true;
            ingredienteCarne.unidadesCocina = ingredienteCarne.capacidadMaxIngrediente;
            prefabIngrediente.SetActive(true);

            botonesTiendaIngrediente[0].SetActive(false);
            botonesTiendaIngrediente[1].SetActive(true);
        }
    }

    

}
