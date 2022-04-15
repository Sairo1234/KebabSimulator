using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    //Cuadro de diálogo
    public GameObject PanelDialogo;

    public void mostrarDialogo()
    {
        StartCoroutine(timerDialogo());
       
    }

    public void ocultarDialogo()
    {
        PanelDialogo.SetActive(false);
        
    }

    IEnumerator timerDialogo()
    {
        yield return new WaitForSeconds(1);
        PanelDialogo.SetActive(true);
    }
    

}
