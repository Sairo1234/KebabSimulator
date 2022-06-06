using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MejorarVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;
    public GameObject prefabIngredienteVerdura;

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
        if (ingredienteVerdura.nivel == 0)
        {
            if (dineroJugador >= ingredienteVerdura.costeCompra)
            {
                //Comprar de mejora
                jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteVerdura.costeMejora);

                //Cambio de la Info del Ingredinte
                ingredienteVerdura.nombre = nombresMejoras[0];
                ingredienteVerdura.nivel++;
                ingredienteVerdura.capacidadMaxIngrediente = newCapacidadMaxima[0];
                prefabIngredienteVerdura.GetComponent<AñadirVerdura>().cantidad = newCapacidadMaxima[0];

                //Cambio de modelo
                modelosMejorasIngredientes[0].SetActive(false);
                modelosMejorasIngredientes[1].SetActive(true);

                //Cambio de niveles mejoras
                ingredienteVerdura.DesbloqueoMejora = newDesbloqueosMejoraNivelDos;

                //Cambio de precios
                ingredienteVerdura.costeMejora = newCosteMejoraNivelDos;
                ingredienteVerdura.costeCompraUnidades = newCostesCompraUnidades[0];

                //Bloqueo Boton
                animatorMejora.SetTrigger("Mejorado");
                StartCoroutine(cambioImagenMejoraUno());
            }
        }

        //Mejora de nivel 2
        else if (ingredienteVerdura.nivel == 1)
        {
            if (dineroJugador >= ingredienteVerdura.costeCompra)
            {
                //Comprar de mejora
                jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteVerdura.costeMejora);

                //Cambio de la Info del Ingredinte
                ingredienteVerdura.nombre = nombresMejoras[1];
                ingredienteVerdura.nivel++;
                ingredienteVerdura.capacidadMaxIngrediente = newCapacidadMaxima[1];
                prefabIngredienteVerdura.GetComponent<AñadirVerdura>().cantidad = newCapacidadMaxima[1];

                //Cambio de modelo
                modelosMejorasIngredientes[1].SetActive(false);
                modelosMejorasIngredientes[2].SetActive(true);

                //Cambio de precios
                ingredienteVerdura.costeCompraUnidades = newCostesCompraUnidades[0];

                //Bloqueo Boton
                animatorMejora.SetTrigger("Mejorado");
                StartCoroutine(cambioImagenMejoraDos());
            }
        }
    }

    public void comprobarDesbloqueoMejora()
    {
        if (ingredienteVerdura.DesbloqueoMejora <= nivelJugador && ingredienteVerdura.nivel < 2)
        {
            animatorCandado.SetTrigger("Desbloqueado");
            StartCoroutine(mostrarAnimacionDesbloqueoMejora());
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
