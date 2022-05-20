using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MejorarSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Salsa")]
    public Salsa ingredienteSalsa;
    public GameObject prefabIngredienteSalsa;

    [Header("Info Ingrediente Mejorado")]
    public string[] nombresMejoras;
    public int[] newCapacidadMaxima;
    public GameObject[] modelosMejorasIngredientes = new GameObject[3];

    [Header("Nuevos niveles de desbloqueo")]
    public int newDesbloqueosMejoraNivelDos;

    [Header("Nuevos costes y precios")]
    public float newCosteMejoraNivelDos;
    public float[] newCostesCompraUnidades;

    //--------------- Jugador ---------------//
    [Header("Jugador")]
    public GameObject jugador;
    public float dineroJugador;
    public int nivelJugador;

    //--------------- Boton ---------------//
    [Header("Boton de Mejora")]
    public Button botonMejoraIngrediente;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        dineroJugador = jugador.GetComponent<ReputacionDinero>().Dinero;
        nivelJugador = jugador.GetComponent<ReputacionDinero>().Nivel;

        comprobarDesbloqueoMejora();
    }


    public void MejoraIngrediente()
    {

        //Mejora de nivel 1
        if (ingredienteSalsa.nivel == 0)
        {
            if (dineroJugador >= ingredienteSalsa.costeCompra)
            {
                //Comprar de mejora
                jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteSalsa.costeMejora);

                //Cambio de la Info del Ingredinte
                ingredienteSalsa.nombre = nombresMejoras[0];
                ingredienteSalsa.nivel++;
                ingredienteSalsa.capacidadMaxIngrediente = newCapacidadMaxima[0];
                prefabIngredienteSalsa.GetComponent<AñadirSalsa>().cantidad = newCapacidadMaxima[0];

                //Cambio de modelo
                modelosMejorasIngredientes[0].SetActive(false);
                modelosMejorasIngredientes[1].SetActive(true);

                //Cambio de niveles mejoras
                ingredienteSalsa.DesbloqueoMejora = newDesbloqueosMejoraNivelDos;

                //Cambio de precios
                ingredienteSalsa.costeMejora = newCosteMejoraNivelDos;
                ingredienteSalsa.costeCompraUnidades = newCostesCompraUnidades[0];

                //Bloqueo Boton
                botonMejoraIngrediente.interactable = false;
            }
        }

        //Mejora de nivel 2
        else if (ingredienteSalsa.nivel == 1)
        {
            if (dineroJugador >= ingredienteSalsa.costeCompra)
            {
                //Comprar de mejora
                jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteSalsa.costeMejora);

                //Cambio de la Info del Ingredinte
                ingredienteSalsa.nombre = nombresMejoras[1];
                ingredienteSalsa.nivel++;
                ingredienteSalsa.capacidadMaxIngrediente = newCapacidadMaxima[1];
                prefabIngredienteSalsa.GetComponent<AñadirSalsa>().cantidad = newCapacidadMaxima[1];

                //Cambio de modelo
                modelosMejorasIngredientes[1].SetActive(false);
                modelosMejorasIngredientes[2].SetActive(true);

                //Cambio de precios
                ingredienteSalsa.costeCompraUnidades = newCostesCompraUnidades[0];

                //Bloqueo Boton
                botonMejoraIngrediente.interactable = false;
                botonMejoraIngrediente.GetComponentInChildren<Text>().text = "Max";
            }
        }
    }

    public void comprobarDesbloqueoMejora()
    {
        if (ingredienteSalsa.DesbloqueoMejora <= nivelJugador && ingredienteSalsa.nivel < 2)
        {
                botonMejoraIngrediente.interactable = true;
         }
    }
}
