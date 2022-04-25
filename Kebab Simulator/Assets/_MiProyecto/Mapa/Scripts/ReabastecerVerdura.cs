using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReabastecerVerdura : MonoBehaviour
{
    [Header("Ingrediente de Verdura")]
    public GameObject ingredienteVerduraAlmacen;

    //--------------------------------------------------------------------------//
    //------------------------------- REABASTECER ------------------------------//

    public void reabastecerIngredienteVerdura()
    {
        ingredienteVerduraAlmacen.GetComponent<AñadirVerdura>().cantidad = 5;
    }
}
