using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;

    [Header("Prefab del Ingrediente")]
    public GameObject prefabIngrediente;

    [Header("Jugador")]
    public GameObject jugador;
    public float dineroJugador;

    [Header("Boton Compra")]
    public GameObject[] botonesTiendaIngrediente;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        dineroJugador = jugador.GetComponent<ReputacionDinero>().Dinero;
    }

    public void comprarIngrediente()
    {
        if (ingredienteVerdura.estaDesbloqueado == true && dineroJugador >= ingredienteVerdura.costeCompra)
        {
            jugador.GetComponent<ReputacionDinero>().TakeDinero(-ingredienteVerdura.costeCompra);

            ingredienteVerdura.estaComprado = true;
            ingredienteVerdura.unidadesCocina = ingredienteVerdura.capacidadMaxIngrediente;
            prefabIngrediente.SetActive(true);

            botonesTiendaIngrediente[0].SetActive(false);
            botonesTiendaIngrediente[1].SetActive(true);
        }
    }
}
