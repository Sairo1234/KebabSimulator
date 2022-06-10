using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("HUDs")]
    public GameObject HUDPrincipal;
    public GameObject HUDSecundario;

    [Header("Secciones")]
    public GameObject SeccionCarne;
    public GameObject SeccionVerdura;
    public GameObject SeccionSalsa;

    private GameObject jugador;

    //Desplazamiento
    [Header("Desplazamiento")]
    public GameObject gameManager;


    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

   /* private void Update()
    {
       if(HUDSecundario.active)
        {
            gameManager.GetComponent<DesplazamientoController>().desactivarDesplazamientoPunto();
        }
    }*/

    //--------------------------------------------------------------------------//
    //------------------------------ HUD Principal -----------------------------//

    public void mostrarHUD()
    {
        HUDPrincipal.SetActive(false);
        HUDSecundario.SetActive(true);
    }

    public void ocultarHUD()
    {
        HUDPrincipal.SetActive(true);
        HUDSecundario.SetActive(false);
        gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
        this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
        this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
    }


    //--------------------------------------------------------------------------//
    //---------------------------- HUD Seccion Carne ---------------------------//

    public void mostrarSeccionCarne()
    {
        SeccionCarne.SetActive(true);
        SeccionVerdura.SetActive(false);
        SeccionSalsa.SetActive(false);
    }

    //--------------------------------------------------------------------------//
    //-------------------------- HUD Seccion Verdura ---------------------------//

    public void mostrarSeccionVerdura()
    {
        SeccionCarne.SetActive(false);
        SeccionVerdura.SetActive(true);
        SeccionSalsa.SetActive(false);
    }

    //--------------------------------------------------------------------------//
    //---------------------------- HUD Seccion Salsa ---------------------------//

    public void mostrarSeccionSalsa()
    {
        SeccionCarne.SetActive(false);
        SeccionVerdura.SetActive(false);
        SeccionSalsa.SetActive(true);
    }

    
}
