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
   

    public void eliminarKebab()
    {
        if (LocalizacionKebab.childCount != 0)
        {
            kebabParaTirar = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            Destroy(kebabParaTirar);
            animatorBasura.SetTrigger("AbrirBasura");
            Debug.Log("Se ha tirado el kebab");
        }
        else
        {
            Debug.Log("No hay ningun kebab para tirar");
        }
    }
}



