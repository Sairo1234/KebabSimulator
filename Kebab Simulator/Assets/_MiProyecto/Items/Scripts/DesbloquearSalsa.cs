using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloquearSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Salsa")]
    public Salsa ingredienteSalsa;

    [Header("Jugador")]
    public GameObject jugador;
    public int nivelJugador;

    [Header("Boton Compra")]
    public Button botonComprarIngrediente;

    [Header("Animator")]
    public Animator animatorDesbloqueo;
    public Animator animatorCandado;

    private bool haSidoDesbloqueado = false;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void OnEnable()
    {
        if (haSidoDesbloqueado == false)
        {
            nivelJugador = jugador.GetComponent<ReputacionDinero>().Nivel;
            desbloquearIngrediente();
        }
    }

    public void desbloquearIngrediente()
    {
        if (nivelJugador >= ingredienteSalsa.DesbloqueoCompra)
        {
            ingredienteSalsa.estaDesbloqueado = true;
            animatorCandado.SetTrigger("Desbloqueado");
            haSidoDesbloqueado = true;
            StartCoroutine(mostrarAnimacionCandado());
        }
    }

    //-----------------------------------------------------------------------//
    //---------------------------Mostrar animacion---------------------------//

    IEnumerator mostrarAnimacionCandado()
    {
        yield return new WaitForSeconds(2);
        animatorDesbloqueo.SetTrigger("Desbloqueado");
        StartCoroutine(mostrarAnimacion());
    }

    IEnumerator mostrarAnimacion()
    {
        yield return new WaitForSeconds(2);
        botonComprarIngrediente.interactable = true;
    }
}
