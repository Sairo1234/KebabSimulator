using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReabastecerSalsa : MonoBehaviour
{
    [Header("Ingrediente de Salsa")]
    public GameObject ingredienteSalsaAlmacen;

    //--------------------------------------------------------------------------//
    //------------------------------- REABASTECER ------------------------------//

    public void reabastecerIngredienteSalsa()
    {
        ingredienteSalsaAlmacen.GetComponent<AñadirSalsa>().cantidad = 10;
    }
}
