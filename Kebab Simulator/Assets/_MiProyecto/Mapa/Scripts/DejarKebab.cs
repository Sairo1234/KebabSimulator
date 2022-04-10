using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DejarKebab : MonoBehaviour
{

    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //Espacios de la mesa
    [Header("Espacios de la mesa")]
    public List<Transform> EspaciosDejarKebab = new List<Transform>();

    //Kebab que se va a dejar
    private GameObject kebabParaDejar;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void OnMouseDown()
    {
        if(maximaCapacidadMesa() == false)
        {
            buscarKebabParaDejar();
            if (kebabParaDejar != null)
            {
                colocarKebabEnMesa();
            }
        }
        else
        {
            Debug.Log("La mesa esta llena");
        }
    }

    //--------------------------------------------------------------------------//
    //------------------------------- DEJAR KEBAB ------------------------------//

    public void buscarKebabParaDejar()
    {
        GameObject kebabEnPreparacion = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
        if (kebabEnPreparacion != null)
        {
            kebabParaDejar = kebabEnPreparacion;
        }
    }

    public void colocarKebabEnMesa()
    {
        Destroy(GameObject.FindGameObjectWithTag("KebabEnPreparacion"));
        for(int i = 0; i<= EspaciosDejarKebab.Count - 1; i++)
        {
            if(EspaciosDejarKebab[i].childCount == 0 && kebabParaDejar != null)
            {
                GameObject KebabEnMesa = Instantiate(kebabParaDejar, EspaciosDejarKebab[i]);
                KebabEnMesa.tag = "KebabEnMesa";
                KebabEnMesa.GetComponent<OutlineDeObjeto>().enabled = true;
                KebabEnMesa.GetComponent<CogerKebab>().enabled = true;
                kebabParaDejar = null;
            }
        }
        
    }

    //--------------------------------------------------------------------------//
    //------------------------ COMPROBACIÓN MESA LLENA -------------------------//

    public bool maximaCapacidadMesa()
    {
        for(int i = 0; i <= EspaciosDejarKebab.Count - 1; i++)
        {
            if(EspaciosDejarKebab[i].childCount == 0)
            {
                return false;
            }
        }
        return true;
    }
}
