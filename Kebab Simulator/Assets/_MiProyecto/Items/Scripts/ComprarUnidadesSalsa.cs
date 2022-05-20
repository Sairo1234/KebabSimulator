using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarUnidadesSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Salsa")]
    public Salsa ingredienteSalsa;

    [Header("Jugador")]
    public GameObject jugador;
    public float dineroJugador;
    public int nivelJugador;

    [Header("Boton comprar unidades")]
    public Button botonComprarUnidades;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        dineroJugador = jugador.GetComponent<ReputacionDinero>().Dinero;
        nivelJugador = jugador.GetComponent<ReputacionDinero>().Nivel;
        comprobarUnidadesSalsa();
    }

    public void anyadirUnidadesSalsa()
    {
        if (ingredienteSalsa.unidadesAlmacen < 100)
        {
            if (dineroJugador >= ingredienteSalsa.costeCompraUnidades)
            {
                jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteSalsa.costeCompraUnidades);
                ingredienteSalsa.unidadesAlmacen = +5;
            }
        }
    }

    public void comprobarUnidadesSalsa()
    {
        if (ingredienteSalsa.unidadesAlmacen > 99)
        {
            botonComprarUnidades.interactable = false;
            botonComprarUnidades.GetComponentInChildren<Text>().text = "Max";
        }
        else
        {
            botonComprarUnidades.interactable = true;
        }
    }
}
