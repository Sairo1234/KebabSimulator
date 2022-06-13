using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloquearCarne : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

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
        if(nivelJugador >= ingredienteCarne.DesbloqueoCompra)
        {
            ingredienteCarne.estaDesbloqueado = true;
            haSidoDesbloqueado = true;
            animatorCandado.SetTrigger("Desbloqueado");
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
