using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EliminarKebab : MonoBehaviour
{

    //Tirar kebab
    public GameObject papelera;
    public GameObject kebabParaTirar;
    public Transform LocalizacionKebab;

    //Animaciones
    public Animator animatorBasura;

    //Desplazamiento
    [Header("Desplazamiento")]
    public GameObject gameManager;


    public void eliminarKebab()
    {
        if (LocalizacionKebab.childCount != 0)
        {
            kebabParaTirar = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            Destroy(kebabParaTirar);
            animatorBasura.SetTrigger("AbrirBasura");
            StartCoroutine(activarDesplazamientoPunto());

        }
        else
        {
            gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
            this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
        }
    }

    IEnumerator activarDesplazamientoPunto()
    {
        yield return new WaitForSeconds(1);
        gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
        this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorUsandoObjeto = false;
        this.gameObject.GetComponent<DesplazamientoPunto>().estaJugadorHaciendoAccion = false;
    }
}



