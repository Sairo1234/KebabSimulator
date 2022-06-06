using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloquearVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;

    [Header("Jugador")]
    public GameObject jugador;
    public int nivelJugador;

    [Header("Boton Compra")]
    public Button botonComprarIngrediente;

    [Header("Animator")]
    public Animator animatorDesbloqueo;
    public Animator animatorCandado;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Start()
    {
        nivelJugador = jugador.GetComponent<ReputacionDinero>().Nivel;
        desbloquearIngrediente();
    }

    public void desbloquearIngrediente()
    {
        if (nivelJugador >= ingredienteVerdura.DesbloqueoCompra)
        {
            ingredienteVerdura.estaDesbloqueado = true;
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
