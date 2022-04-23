using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacienciaCola : MonoBehaviour
{
    public float timeRemaining = 45;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            this.gameObject.GetComponent<SalidaCliente>().rechazoPedido();
            this.gameObject.GetComponent<SalidaCliente>().salir();
            this.enabled = false;
        }
    }

}
