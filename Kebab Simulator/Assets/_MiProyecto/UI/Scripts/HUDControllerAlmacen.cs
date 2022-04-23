using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControllerAlmacen : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("HUDs")]
    public GameObject HUDPrincipal;
    public GameObject HUDAlmacen;

    [Header("Secciones")]
    public GameObject Principal;
    public GameObject SeccionCarne;
    public GameObject SeccionVerdura;
    public GameObject SeccionSalsa;

    private GameObject jugador;


    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    //--------------------------------------------------------------------------//
    //------------------------------ HUD Principal -----------------------------//

    public void mostrarAlmacenHUD()
    {
        HUDPrincipal.SetActive(false);
        HUDAlmacen.SetActive(true);
        
        jugador.GetComponent<Player_Mov>().enabled = false;
    }

    public void ocultarAlmacenHUD()
    {
        HUDPrincipal.SetActive(true);
        HUDAlmacen.SetActive(false);
        jugador.GetComponent<Player_Mov>().enabled = true;
    }

    public void volverPrincipal()
    {
        Principal.SetActive(true);
        SeccionCarne.SetActive(false);
        SeccionVerdura.SetActive(false);
        SeccionSalsa.SetActive(false);
    }


    //--------------------------------------------------------------------------//
    //---------------------------- HUD Seccion Carne ---------------------------//

    public void mostrarSeccionCarne()
    {
        Principal.SetActive(false);
        SeccionCarne.SetActive(true);
    }

    //--------------------------------------------------------------------------//
    //-------------------------- HUD Seccion Verdura ---------------------------//

    public void mostrarSeccionVerdura()
    {
        Principal.SetActive(false);
        SeccionVerdura.SetActive(true);
    }

    //--------------------------------------------------------------------------//
    //---------------------------- HUD Seccion Salsa ---------------------------//

    public void mostrarSeccionSalsa()
    {
        Principal.SetActive(false);
        SeccionSalsa.SetActive(true);
    }

    
}
