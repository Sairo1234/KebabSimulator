using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour
{
    public GameObject Cliente;
    SalidaCliente salida;
    
 
    private void OnMouseDown()
    {
        this.gameObject.GetComponent<CambioCamara>().cambioCamaraBarraMain();
        Cliente.GetComponent<Dialogo>().ocultarDialogo();
    }
}
