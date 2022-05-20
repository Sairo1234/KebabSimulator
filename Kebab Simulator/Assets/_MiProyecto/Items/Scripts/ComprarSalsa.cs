using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Salsa")]
    public Salsa ingredienteSalsa;

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
        if (ingredienteSalsa.estaDesbloqueado == true && dineroJugador >= ingredienteSalsa.costeCompra)
        {
            jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteSalsa.costeCompra);

            ingredienteSalsa.estaComprado = true;
            ingredienteSalsa.unidadesAlmacen = ingredienteSalsa.capacidadMaxIngrediente;
            prefabIngrediente.SetActive(true);

            botonesTiendaIngrediente[0].SetActive(false);
            botonesTiendaIngrediente[1].SetActive(true);
        }
    }

}
