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

    //Desplazamiento
    [Header("Desplazamiento")]
    public GameObject gameManager;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//


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
                KebabEnMesa.GetComponent<MostrarIngredientesKebab>().enabled = true;
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

    public void dejarKebab()
    {
        buscarKebabParaDejar();
        if (kebabParaDejar != null)
        {
            colocarKebabEnMesa();
            StartCoroutine(activarDesplazamientoPunto());
        }
        /*if (maximaCapacidadMesa() == false)
        {
            
        }
        else
        {
            gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
        }*/
    }

    IEnumerator activarDesplazamientoPunto()
    {
        yield return new WaitForSeconds(2);
        gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
        this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
        this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
    }
}
