using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CambioCamara : MonoBehaviour
{
    private CinemachineVirtualCamera VirtualCameraBarra;
    private GameObject cliente;

    private void Start()
    {
        VirtualCameraBarra = GameObject.FindGameObjectWithTag("CamaraBarra").GetComponent<CinemachineVirtualCamera>();
        cliente = this.gameObject;
    }

    private void cambioCamaraMainBarra()
    {
        this.gameObject.GetComponent<OutlineDeObjeto>().enabled = false;
        VirtualCameraBarra.Priority = 2;
        Camera.main.orthographic = false;
        cliente.GetComponent<Dialogo>().mostrarDialogo();
    }

    public void cambioCamaraBarraMain()
    {
        this.gameObject.GetComponent<OutlineDeObjeto>().enabled = true;
        VirtualCameraBarra.Priority = 0;
        //Camera.main.orthographic = true;
        StartCoroutine(Ortografico());
    }

    IEnumerator Ortografico()
    {
        yield return new WaitForSeconds(1);
        Camera.main.orthographic = true;
    }
}
