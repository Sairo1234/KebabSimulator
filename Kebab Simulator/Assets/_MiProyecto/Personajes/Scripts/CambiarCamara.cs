using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CambiarCamara : MonoBehaviour
{

    public CinemachineVirtualCamera VirtualCameraBarra;

    private int counter = 0;

    private void OnMouseDown()
    {

        if (counter == 0)
        {
            VirtualCameraBarra.Priority = 2;
            Camera.main.orthographic = false;

            counter++;
            Debug.Log("hola");
        }
        else
        {
            VirtualCameraBarra.Priority = 0;
            StartCoroutine(Ortografico());
            counter--;
            Debug.Log("adios");
        }
    }

    IEnumerator Ortografico()
    {

        yield return new WaitForSeconds(2);
        Camera.main.orthographic = true;
    }
}
