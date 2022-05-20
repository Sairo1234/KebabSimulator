using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerTiendaSalsa : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Salsa")]
    public Salsa ingredienteSalsa;

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
        if (ingredienteSalsa.estaDesbloqueado == true)
        {
            botonesTiendaIngrediente[0].GetComponent<Button>().interactable = true;
        }
    }

    public void comprobarCompraIngrediente()
    {
        if (ingredienteSalsa.estaComprado == true)
        {
            botonesTiendaIngrediente[0].gameObject.SetActive(false);
            botonesTiendaIngrediente[1].gameObject.SetActive(true);
        }
    }
}
