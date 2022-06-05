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
    public GameObject[] estadosBotonUnidades;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

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
                ingredienteCarne.unidadesAlmacen= ingredienteCarne.unidadesAlmacen  + 5;
            }
        }
    }

    public void comprobarUnidadesCarne()
    {
        if (ingredienteCarne.unidadesAlmacen > 99)
        {
            botonComprarUnidades.interactable = false;
            estadosBotonUnidades[0].SetActive(false);
            estadosBotonUnidades[1].SetActive(true);

        }
        else
        {
            botonComprarUnidades.interactable = true;
            estadosBotonUnidades[0].SetActive(true);
            estadosBotonUnidades[1].SetActive(false);
        }
    }
}
