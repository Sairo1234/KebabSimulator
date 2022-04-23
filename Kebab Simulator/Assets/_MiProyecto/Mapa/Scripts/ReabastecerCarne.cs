using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReabastecerCarne : MonoBehaviour
{
    [Header("Ingrediente de Carne")]
    public GameObject ingredienteCarneAlmacen;

    //--------------------------------------------------------------------------//
    //------------------------------- REABASTECER ------------------------------//

    public void reabastecerIngredienteCarne()
    {
        ingredienteCarneAlmacen.GetComponent<AñadirCarne>().cantidad = 10;
    }

}
