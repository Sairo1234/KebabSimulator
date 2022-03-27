using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarKebab : MonoBehaviour
{
    public GameObject kebabParaTirar;
    public Transform LocalizacionKebab;
    private void OnMouseDown()
    {
        eliminarKebab();
    }

    public void eliminarKebab()
    {
        if (LocalizacionKebab.childCount != 0)
        {
            kebabParaTirar = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
            Destroy(kebabParaTirar);
            Debug.Log("Se ha tirado el kebab");
        }
        else
        {
            Debug.Log("No hay ningun kebab para tirar");
        }
    }
}

