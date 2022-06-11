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
    public float[] newPreciosVenta;

    //--------------- Jugador ---------------//
    [Header("Jugador")]
    public GameObject jugador;
    public float dineroJugador;
    public int nivelJugador;

    //--------------- Boton ---------------//
    [Header("Boton de Mejora")]
    public Button botonMejoraIngrediente;
    public GameObject[] estadosBotonMejora;
    public Animator animatorCandado;

    [Header("Animator")]
    public Animator animatorMejora;

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
                ingredienteCarne.unidadesCocina = newCapacidadMaxima[0];


               //Cambio de modelo
                modelosMejorasIngredientes[0].SetActive(false);
                modelosMejorasIngredientes[1].SetActive(true);

                //Cambio de niveles mejoras
                ingredienteCarne.DesbloqueoMejora = newDesbloqueosMejoraNivelDos;

                //Cambio de precios
                ingredienteCarne.costeMejora = newCosteMejoraNivelDos;
                ingredienteCarne.costeCompraUnidades = newCostesCompraUnidades[0];
                ingredienteCarne.precioVenta = newPreciosVenta[0];

                //Bloqueo Boton
                animatorMejora.SetTrigger("Mejorado");
                StartCoroutine(cambioImagenMejoraUno());
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
                ingredienteCarne.unidadesCocina = newCapacidadMaxima[1];

                //Cambio de modelo
                modelosMejorasIngredientes[1].SetActive(false);
                modelosMejorasIngredientes[2].SetActive(true);

                //Cambio de precios
                ingredienteCarne.costeCompraUnidades = newCostesCompraUnidades[1];
                ingredienteCarne.precioVenta = newPreciosVenta[1];

                //Bloqueo Boton
                animatorMejora.SetTrigger("Mejorado");
                StartCoroutine(cambioImagenMejoraDos());
               
            }
        }
    }


    //--------------------------------------------------------------//
    //----------------------- ComprobarMejora ----------------------//

    public void comprobarDesbloqueoMejora()
    {
        if (ingredienteCarne.DesbloqueoMejora <= nivelJugador && ingredienteCarne.nivel < 2)
        {
            animatorCandado.SetTrigger("Desbloqueado");
            StartCoroutine(mostrarAnimacionDesbloqueoMejora());
        }
        else if(ingredienteCarne.nivel > 2)
        {
            botonMejoraIngrediente.interactable = false;
            estadosBotonMejora[0].SetActive(false);
            estadosBotonMejora[1].SetActive(false);
            estadosBotonMejora[2].SetActive(true);
        }
        else 
        {
            botonMejoraIngrediente.interactable = false;
            estadosBotonMejora[0].SetActive(true);
            estadosBotonMejora[1].SetActive(false);
        }
    }

    IEnumerator mostrarAnimacionDesbloqueoMejora()
    {
        yield return new WaitForSeconds(2);

        animatorCandado.SetTrigger("Volver");
        StartCoroutine(cambioEstadoBotonMejora());
    }

    IEnumerator cambioEstadoBotonMejora()
    {
        botonMejoraIngrediente.interactable = true;
        estadosBotonMejora[0].SetActive(false);
        estadosBotonMejora[1].SetActive(true);
        yield return new WaitForSeconds(1);

    }

    //--------------------------------------------------------------//
    //----------------------- MejoraAnimacion ----------------------//

    IEnumerator cambioImagenMejoraUno()
    {
        yield return new WaitForSeconds(1);
        botonMejoraIngrediente.interactable = false;
        estadosBotonMejora[0].SetActive(true);
        estadosBotonMejora[1].SetActive(false);
        animatorMejora.SetTrigger("Volver");
    }
    IEnumerator cambioImagenMejoraDos()
    {
        yield return new WaitForSeconds(1);
        botonMejoraIngrediente.interactable = false;
        estadosBotonMejora[0].SetActive(false);
        estadosBotonMejora[1].SetActive(false);
        estadosBotonMejora[2].SetActive(true);
        animatorMejora.SetTrigger("Volver");
    }
}
