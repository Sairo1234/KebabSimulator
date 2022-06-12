using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarEmociones : MonoBehaviour
{
    public GameObject PanelEmocionAceptado;
    public GameObject PanelEmocionRechazado;
    public GameObject PanelEmocionKebabPerfecto;
    public GameObject PanelEmocionKebabMalo;

    public void MostrarAceptado()
    {
        PanelEmocionAceptado.SetActive(true);
        StartCoroutine(FinAceptado());
    }
    IEnumerator FinAceptado()
    {
        yield return new WaitForSeconds(1);
        PanelEmocionAceptado.SetActive(false);
    }

    public void MostrarRechazado()
    {
        PanelEmocionRechazado.SetActive(true);
        StartCoroutine(FinRechazado());
    }
    IEnumerator FinRechazado()
    {
        yield return new WaitForSeconds(1);
        PanelEmocionRechazado.SetActive(false);
    }

    public void MostrarKebabPerfecto()
    {
        PanelEmocionKebabPerfecto.SetActive(true);
        StartCoroutine(FinKebabPerfecto());
    }

    IEnumerator FinKebabPerfecto()
    {
        yield return new WaitForSeconds(1);
        PanelEmocionKebabPerfecto.SetActive(false);
    }

    public void MostrarKebabMalo()
    {
        PanelEmocionKebabMalo.SetActive(true);
        StartCoroutine(FinKebabMalo());
    }

    IEnumerator FinKebabMalo()
    {
        yield return new WaitForSeconds(1);
        PanelEmocionKebabMalo.SetActive(false);
    }
}
