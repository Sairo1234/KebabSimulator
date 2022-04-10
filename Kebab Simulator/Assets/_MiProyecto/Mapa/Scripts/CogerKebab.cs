using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerKebab : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //Posicion SpawnKebab
    private Transform puntoSpawnKebab;

    //Kebab que se va a coger
    private GameObject kebabParaCoger;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void OnMouseDown()
    {
        kebabParaCoger = this.gameObject;
        colocarKebabEnJugador();
    }

    //--------------------------------------------------------------------------//
    //----------------------- COLOCAR KEBAB EN JUGADOR -------------------------//

    public void colocarKebabEnJugador()
    {
        buscarSpawnKebab();
        if (puntoSpawnKebab.childCount == 0)
        {
            Destroy(this.gameObject);
            GameObject KebabEnJugador = Instantiate(kebabParaCoger, puntoSpawnKebab);
            KebabEnJugador.tag = "KebabEnPreparacion";
            KebabEnJugador.GetComponent<OutlineDeObjeto>().enabled = true;
            KebabEnJugador.GetComponent<CogerKebab>().enabled = false;
        }
        else
        {
            Debug.Log("Tienes un kebab en la mano");
        }

    }

    public void buscarSpawnKebab()
    {
        GameObject SpawnKebab = GameObject.FindGameObjectWithTag("SpawnKebab");
        puntoSpawnKebab = SpawnKebab.transform;
    }

}
