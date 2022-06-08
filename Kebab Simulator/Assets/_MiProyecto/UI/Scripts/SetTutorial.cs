using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTutorial : MonoBehaviour
{
    [Header("Tutoriales")]
    public GameObject TutorialGeneral;
    public GameObject TutorialCliente;
    public GameObject TutorialKebab;
    public GameObject TutorialTienda;
    public GameObject TutorialAlmacen;

    [Header("Bools")]
    public bool TGNoHaSalido = true;
    public bool TCNoHaSalido = true;
    public bool TKNoHaSalido = true;
    public bool TTiendaNoHaSalido = true;
    public bool TAlmacenNoHaSalido = true;

    [Header("DataInfo")]
    public DataPlayerInfo infoJugador;

    [Header("GameObjects de la escena")]
    public GameObject[] DetonantesTK;
    public GameObject cliente;
    public GameObject canvasTienda;
    public GameObject canvasAlmacen;
    public GameObject dialogo;
    private void Start()
    {
        if (TGNoHaSalido)
        {
            TutorialGeneral.SetActive(true);
            TGNoHaSalido = false;
        }

    }
    private void Update()
    {
        //guardarTutoriales();
        if (cliente == null)
        {
            cliente = GameObject.FindGameObjectWithTag("Cliente");
        }
        //look for a gameobject with the tag Dialogo
        dialogo = GameObject.FindGameObjectWithTag("Dialogo");

    }

    /*public void guardarTutoriales()
    {
        infoJugador.TGNoHaSalido = TGNoHaSalido;
        infoJugador.TCNoHaSalido = TCNoHaSalido;
        infoJugador.TKNoHaSalido = TKNoHaSalido;
        infoJugador.TTiendaNoHaSalido = TTiendaNoHaSalido;
        infoJugador.TAlmacenNoHaSalido = TAlmacenNoHaSalido;
    }*/


    public void PonerTutorialCliente()
    {
        if (cliente != null)
        {
            if (TCNoHaSalido && !TutorialKebab.activeSelf && !TutorialGeneral.activeSelf)
            {
                TutorialCliente.SetActive(true);
                TCNoHaSalido = false;
            }
        }
    }

    public void PonerTutorialIngredientes()
    {
        if (dialogo != null)
        {
            if (TKNoHaSalido && !TutorialCliente.activeSelf && !TutorialGeneral.activeSelf && !dialogo.activeSelf)
            {
                TutorialKebab.SetActive(true);
                TKNoHaSalido = false;
            }
        }
        else
        {
            if (TKNoHaSalido && !TutorialCliente.activeSelf && !TutorialGeneral.activeSelf)
            {
                TutorialKebab.SetActive(true);
                TKNoHaSalido = false;
            }
        }

    }


}
