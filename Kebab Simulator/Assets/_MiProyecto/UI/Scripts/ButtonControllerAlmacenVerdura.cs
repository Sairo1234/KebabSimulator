using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerAlmacenVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Update()
    {
        comprobarCompraIngrediente();
    }

    public void comprobarCompraIngrediente()
    {
        if (ingredienteVerdura.estaComprado == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
