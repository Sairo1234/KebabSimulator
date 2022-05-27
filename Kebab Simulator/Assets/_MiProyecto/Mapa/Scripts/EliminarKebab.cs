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
            gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
            Debug.Log("Se ha tirado el kebab");
        }
        else
        {
            gameManager.GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
            Debug.Log("No hay ningun kebab para tirar");
        }
    }
}



