using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarUnidadesVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;

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
        comprobarUnidadesVerdura();
    }

    public void anyadirUnidadesVerdura()
    {
        if (ingredienteVerdura.unidadesAlmacen < 100)
        {
            if (dineroJugador >= ingredienteVerdura.costeCompraUnidades)
            {
                jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteVerdura.costeCompraUnidades);
                ingredienteVerdura.unidadesAlmacen = ingredienteVerdura.unidadesAlmacen + 5;
            }
        }
    }

    public void comprobarUnidadesVerdura()
    {
        if (ingredienteVerdura.unidadesAlmacen > 99)
        {
            botonComprarUnidades.interactable = false;
            botonComprarUnidades.GetComponentInChildren<Text>().text = "Max";
        }
        else if (dineroJugador <= ingredienteVerdura.costeCompraUnidades)
        {
            botonComprarUnidades.interactable = false;
        }
        else
        {
            botonComprarUnidades.interactable = true;
        }
    }
}
