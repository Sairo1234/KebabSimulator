using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MejorarCarne : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;
    public GameObject prefabIngredienteCarne;

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
        if (ingredienteCarne.nivel == 0)
        {
            if (dineroJugador >= ingredienteCarne.costeCompra)
            {
                //Comprar de mejora
                jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteCarne.costeMejora);

                //Cambio de la Info del Ingredinte
                ingredienteCarne.nombre = nombresMejoras[0];
                ingredienteCarne.nivel++;
                ingredienteCarne.capacidadMaxIngrediente = newCapacidadMaxima[0];
                prefabIngredienteCarne.GetComponent<AñadirCarne>().cantidad = newCapacidadMaxima[0];

                //Cambio de modelo
                modelosMejorasIngredientes[0].SetActive(false);
                modelosMejorasIngredientes[1].SetActive(true);

                //Cambio de niveles mejoras
                ingredienteCarne.DesbloqueoMejora = newDesbloqueosMejoraNivelDos;

                //Cambio de precios
                ingredienteCarne.costeMejora = newCosteMejoraNivelDos;
                ingredienteCarne.costeCompraUnidades = newCostesCompraUnidades[0];

                //Bloqueo Boton
                botonMejoraIngrediente.interactable = false;
            }
        }

        //Mejora de nivel 2
        else if (ingredienteCarne.nivel == 1)
        {
            if (dineroJugador >= ingredienteCarne.costeCompra)
            {
                //Comprar de mejora
                jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteCarne.costeMejora);

                //Cambio de la Info del Ingredinte
                ingredienteCarne.nombre = nombresMejoras[1];
                ingredienteCarne.nivel++;
                ingredienteCarne.capacidadMaxIngrediente = newCapacidadMaxima[1];
                prefabIngredienteCarne.GetComponent<AñadirCarne>().cantidad = newCapacidadMaxima[1];

                //Cambio de modelo
                modelosMejorasIngredientes[1].SetActive(false);
                modelosMejorasIngredientes[2].SetActive(true);

                //Cambio de precios
                ingredienteCarne.costeCompraUnidades = newCostesCompraUnidades[0];

                //Bloqueo Boton
                botonMejoraIngrediente.interactable = false;
                botonMejoraIngrediente.GetComponentInChildren<Text>().text = "Max";
            }
        }
    }

    public void comprobarDesbloqueoMejora()
    {
        if (ingredienteCarne.DesbloqueoMejora <= nivelJugador && ingredienteCarne.nivel<2)
        {
            botonMejoraIngrediente.interactable = true;
        }
    }
   
}
