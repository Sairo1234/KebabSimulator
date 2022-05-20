using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerTiendaCarnes : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

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
        if (ingredienteCarne.estaDesbloqueado == true)
        {
            botonesTiendaIngrediente[0].GetComponent<Button>().interactable = true;
        }
    }

    public void comprobarCompraIngrediente()
    {
        if (ingredienteCarne.estaComprado == true)
        {
            botonesTiendaIngrediente[0].gameObject.SetActive(false);
            botonesTiendaIngrediente[1].gameObject.SetActive(true);
        }
    }
}
