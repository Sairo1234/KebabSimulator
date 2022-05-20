using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerTiendaVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;

    [Header("Boton Compra")]
    public GameObject[] botonesTiendaIngrediente;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        comprobarDesbloqueoIngrediente();
        comprobarCompraIngrediente();
    }

    public void comprobarDesbloqueoIngrediente()
    {
        if (ingredienteVerdura.estaDesbloqueado == true)
        {
            botonesTiendaIngrediente[0].GetComponent<Button>().interactable = true;
        }
    }

    public void comprobarCompraIngrediente()
    {
        if (ingredienteVerdura.estaComprado == true)
        {
            botonesTiendaIngrediente[0].gameObject.SetActive(false);
            botonesTiendaIngrediente[1].gameObject.SetActive(true);
        }
    }
}
