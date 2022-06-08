using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPuedeAtender : MonoBehaviour
{

    private void OnMouseDown()
    {
        if (this.gameObject.GetComponent<DesplazamientoPunto>().enabled == false)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            jugador.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Nop");
            jugador.transform.eulerAngles = new Vector3(0, 60, 0);

            jugador.GetComponent<SonidoJugadorController>().PlayFrustrado();
        }
    }
}
