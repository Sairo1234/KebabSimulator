using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarUnidadesCarne : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

    [Header("Jugador")]
    public GameObject jugador;
    public float dineroJugador;
    public int nivelJugador;

    [Header("Boton comprar unidades")]
    public Button botonComprarUnidades;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- M�TODOS --------------------------------------//

    private void Update()
    {
        dineroJugador = jugador.GetComponent<ReputacionDinero>().Dinero;
        nivelJugador = jugador.GetComponent<ReputacionDinero>().Nivel;
        comprobarUnidadesCarne();
    }

    public void anyadirUnidadesCarne()
    {
        if (ingredienteCarne.unidadesAlmacen < 100)
        {
            if (dineroJugador >= ingredienteCarne.costeCompraUnidades)
            {
                jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteCarne.costeCompraUnidades);
                ingredienteCarne.unidadesAlmacen=+5;
            }
        }
    }

    public void comprobarUnidadesCarne()
    {
        if (ingredienteCarne.unidadesAlmacen > 99)
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